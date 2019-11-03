namespace MusicHub
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
            var context = new MusicHubDbContext();

            Mapper.Initialize(config => config.AddProfile<MusicHubProfile>());

            ResetDatabase(context, shouldDropDatabase: true);

            var projectDir = GetProjectDirectory();
            
            ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            ExportEntities(context, projectDir + @"ExportResults/");

            using (var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ImportEntities(MusicHubDbContext context, string baseDir, string exportDir)
        {
            var writers = DataProcessor.Deserializer.ImportWriters(context,
                    File.ReadAllText(baseDir + "Actual - ImportWriters.json"));
            PrintAndExportEntityToFile(writers, exportDir + "ImportWriters.txt");

            var producerAlbums = DataProcessor.Deserializer.ImportProducersAlbums(context,
                    File.ReadAllText(baseDir + "Actual - ImportProducersAlbums.json"));
            PrintAndExportEntityToFile(producerAlbums, exportDir + "ImportProducersAlbums.txt");

            var songs = DataProcessor.Deserializer.ImportSongs(context, 
                File.ReadAllText(baseDir + "Actual - ImportSongs.xml"));
            PrintAndExportEntityToFile(songs, exportDir + "ImportSongs.txt");

            var performers = DataProcessor.Deserializer.ImportSongPerformers(context, 
                File.ReadAllText(baseDir + "Actual - ImportSongPerformers.xml"));
            PrintAndExportEntityToFile(performers, exportDir + "ImportSongPerformers.txt");
        }

        private static void ExportEntities(MusicHubDbContext context, string exportDir)
        {
            var jsonOutput = DataProcessor.Serializer.ExportAlbumsInfo(context, 9);
            Console.WriteLine(jsonOutput);
            File.WriteAllText(exportDir + "Actual - AlbumsInfo.json", jsonOutput);

            var xmlOutput = DataProcessor.Serializer.ExportSongsAboveDuration(context, 4);
            Console.WriteLine(xmlOutput);
            File.WriteAllText(exportDir + "Actual - SongsAboveDuration.xml", xmlOutput);
        }

        private static void ResetDatabase(MusicHubDbContext context, bool shouldDropDatabase = false)
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
