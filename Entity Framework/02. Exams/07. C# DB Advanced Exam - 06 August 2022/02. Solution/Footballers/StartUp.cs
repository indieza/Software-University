namespace Footballers
{
    using System;
    using System.IO;
    using System.Globalization;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            var context = new FootballersContext();

            //Mapper.Initialize(config => config.AddProfile<FootballersProfile>());

            ResetDatabase(context, shouldDropDatabase: true);

            var projectDir = GetProjectDirectory();

            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");

            ExportEntities(context, projectDir + @"ExportResults/");

            using (var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ImportEntities(FootballersContext context, string baseDir, string exportDir)
        {
            var coaches =
                DataProcessor.Deserializer.ImportCoaches(context,
                    File.ReadAllText(baseDir + "coaches.xml"));

            PrintAndExportEntityToFile(coaches, exportDir + "Actual Result - ImportCoaches.txt");

            var teams =
             DataProcessor.Deserializer.ImportTeams(context,
                 File.ReadAllText(baseDir + "teams.json"));

            PrintAndExportEntityToFile(teams, exportDir + "Actual Result - ImportTeams.txt");
        }

        private static void ExportEntities(FootballersContext context, string exportDir)
        {
            var exportCoachesWithTheirFootballers = DataProcessor.Serializer.ExportCoachesWithTheirFootballers(context);
            Console.WriteLine(exportCoachesWithTheirFootballers);
            File.WriteAllText(exportDir + "Actual Result - ExportCoachesWithTheirFootballers.xml", exportCoachesWithTheirFootballers);

            DateTime dateTime = DateTime.ParseExact("31/03/2020", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var exportTeamsWithMostPlayers = DataProcessor.Serializer.ExportTeamsWithMostFootballers(context, dateTime);
            Console.WriteLine(exportTeamsWithMostPlayers);
            File.WriteAllText(exportDir + "Actual Result - ExportTeamsWithMostFootballers.json", exportTeamsWithMostPlayers);
        }

        private static void ResetDatabase(FootballersContext context, bool shouldDropDatabase = false)
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
