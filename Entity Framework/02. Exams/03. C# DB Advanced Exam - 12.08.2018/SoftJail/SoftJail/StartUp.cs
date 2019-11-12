namespace SoftJail
{
    using System;
    using Data;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftJailDbContext();

            Mapper.Initialize(config => config.AddProfile<SoftJailProfile>());

            ResetDatabase(context, shouldDropDatabase: false);

            var projectDir = GetProjectDirectory();

            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            ExportEntities(context, projectDir + @"ExportResults/");

            using (var transaction = context.Database.BeginTransaction())
            {
                BonusTask(context);
                transaction.Rollback();
            }
        }

        private static void BonusTask(SoftJailDbContext context)
        {
            var bonusOutput = DataProcessor.Bonus.ReleasePrisoner(context, 5);
            Console.WriteLine(bonusOutput);
        }

        private static void ImportEntities(SoftJailDbContext context, string baseDir, string exportDir)
        {
            var departmentsCells =
                DataProcessor.Deserializer.ImportDepartmentsCells(context,
                    File.ReadAllText(baseDir + "ImportDepartmentsCells.json"));
            PrintAndExportEntityToFile(departmentsCells, exportDir + "ImportDepartmentsCells.txt");

            var prisonersMails =
                DataProcessor.Deserializer.ImportPrisonersMails(context,
                    File.ReadAllText(baseDir + "ImportPrisonersMails.json"));
            PrintAndExportEntityToFile(prisonersMails, exportDir + "ImportPrisonersMails.txt");

            var officersPrisoners = DataProcessor.Deserializer.ImportOfficersPrisoners(context, File.ReadAllText(baseDir + "ImportOfficersPrisoners.xml"));
            PrintAndExportEntityToFile(officersPrisoners, exportDir + "ImportOfficersPrisoners.txt");
        }

        private static void ExportEntities(SoftJailDbContext context, string exportDir)
        {
            var jsonOutput = DataProcessor.Serializer.ExportPrisonersByCells(context, new[] { 1, 5, 7, 3 });
            Console.WriteLine(jsonOutput);
            File.WriteAllText(exportDir + "PrisonersByCells.json", jsonOutput);

            var xmlOutput = DataProcessor.Serializer.ExportPrisonersInbox(context, "Melanie Simonich,Diana Ebbs,Binni Cornhill");
            Console.WriteLine(xmlOutput);
            File.WriteAllText(exportDir + "PrisonersInbox.xml", xmlOutput);
        }
        private static void ResetDatabase(SoftJailDbContext context, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                context.Database.EnsureDeleted();
            }

            if (context.Database.EnsureCreated())
            {
                return;
            }

            var disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlCommand(disableIntegrityChecksQuery);

            var deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
            context.Database.ExecuteSqlCommand(deleteRowsQuery);

            var enableIntegrityChecksQuery =
                "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
            context.Database.ExecuteSqlCommand(enableIntegrityChecksQuery);

            var reseedQuery =
                "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
            context.Database.ExecuteSqlCommand(reseedQuery);
        }

        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }

        private static string GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("netcoreapp") ? @"../../../" : string.Empty;

            return relativePath;
        }
    }
}