namespace Cinema
{
    using System;
    using System.IO;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CinemaContext();

            Mapper.Initialize(config => config.AddProfile<CinemaProfile>());

            ResetDatabase(context, shouldDropDatabase: true);

            var projectDir = GetProjectDirectory();

           ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");

            ExportEntities(context, projectDir + @"ExportResults/");

            using (var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ImportEntities(CinemaContext context, string baseDir, string exportDir)
        {
            var movies =
                DataProcessor.Deserializer.ImportMovies(context,
                    File.ReadAllText(baseDir + "movies.json"));
            PrintAndExportEntityToFile(movies, exportDir + "Actual Result - ImportMovies.txt");

            var hallSeats =
                DataProcessor.Deserializer.ImportHallSeats(context,
                    File.ReadAllText(baseDir + "halls-seats.json"));
            PrintAndExportEntityToFile(hallSeats, exportDir + "Actual Result - ImportHallSeats.txt");

            var projections = DataProcessor.Deserializer.ImportProjections(context,
                File.ReadAllText(baseDir + "projections.xml"));
            PrintAndExportEntityToFile(projections, exportDir + "Actual Result - ImportProjections.txt");

            var customerTickets =
                DataProcessor.Deserializer.ImportCustomerTickets(context,
                    File.ReadAllText(baseDir + "customers-tickets.xml"));
            PrintAndExportEntityToFile(customerTickets, exportDir + "Actual Result - ImportCustomerTickets.txt");
        }

        private static void ExportEntities(CinemaContext context, string exportDir)
        {
            var exportTopMovies = DataProcessor.Serializer.ExportTopMovies(context, 5);
            Console.WriteLine(exportTopMovies);
            File.WriteAllText(exportDir + "Actual Result - ExportTopMovies.json", exportTopMovies);

            var exportTopCustomers = DataProcessor.Serializer.ExportTopCustomers(context, 14);
            Console.WriteLine(exportTopCustomers);
            File.WriteAllText(exportDir + "Actual Result - ExportTopCustomers.xml", exportTopCustomers);
        }

        private static void ResetDatabase(CinemaContext context, bool shouldDropDatabase = false)
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