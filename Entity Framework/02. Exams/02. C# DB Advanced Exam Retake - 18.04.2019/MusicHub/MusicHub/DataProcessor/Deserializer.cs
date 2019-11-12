namespace MusicHub.DataProcessor
{
    using AutoMapper;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.DTO.ImportDtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);
            List<Writer> writers = new List<Writer>();

            StringBuilder sb = new StringBuilder();

            foreach (var writeDto in writersDto)
            {
                var writer = Mapper.Map<Writer>(writeDto);

                bool isValid = IsValid(writer);

                if (isValid == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerDto[]>(jsonString);
            List<Producer> producers = new List<Producer>();

            StringBuilder sb = new StringBuilder();

            foreach (var producerDto in producersDto)
            {
                bool isValidProducer = IsValid(producerDto);
                bool isValidAlbums = producerDto.Albums.All(s => IsValid(s) == true);

                if (isValidProducer == false || isValidAlbums == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Producer producer = new Producer
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    Album album = new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);
                }

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone,
                        producer.Name,
                        producer.Albums.Count));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongDto[]), new XmlRootAttribute("Songs"));
            var songsDto = (ImportSongDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            List<Song> songs = new List<Song>();

            StringBuilder sb = new StringBuilder();

            foreach (var songDto in songsDto)
            {
                bool isValidSong = IsValid(songDto);
                bool isValidGenre = Enum.IsDefined(typeof(Genre), songDto.Genre);
                Album isValidAlbum = context.Albums.Find(songDto.AlbumId);
                Writer isValidWriter = context.Writers.Find(songDto.WriterId);

                if (isValidSong == false ||
                    isValidGenre == false ||
                    isValidAlbum == null ||
                    isValidWriter == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Song song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.Parse(songDto.Duration),
                    CreatedOn = DateTime
                    .ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = (Genre)Enum.Parse(typeof(Genre), songDto.Genre),
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong,
                    song.Name,
                    song.Genre.ToString(),
                    song.Duration.ToString()));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPerformerDto[]), new XmlRootAttribute("Performers"));
            var performersDto = (ImportPerformerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));
            List<Performer> performers = new List<Performer>();

            StringBuilder sb = new StringBuilder();

            foreach (var performerDto in performersDto)
            {
                bool isValidPerformer = IsValid(performerDto);

                if (isValidPerformer == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidSong = true;

                foreach (var songDto in performerDto.PerformersSongs)
                {
                    var targetSong = context.Songs.Find(songDto.Id);

                    if (targetSong == null)
                    {
                        isValidSong = false;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }
                }

                if (isValidSong == true)
                {
                    Performer performer = new Performer
                    {
                        FirstName = performerDto.FirstName,
                        LastName = performerDto.LastName,
                        Age = performerDto.Age,
                        NetWorth = performerDto.NetWorth
                    };

                    foreach (var songDto in performerDto.PerformersSongs)
                    {
                        var targetSong = context.Songs.FirstOrDefault(s => s.Id == songDto.Id);

                        SongPerformer songPerformer = new SongPerformer
                        {
                            PerformerId = performer.Id,
                            Performer = performer,
                            SongId = songDto.Id,
                            Song = targetSong
                        };

                        performer.PerformerSongs.Add(songPerformer);
                    }

                    performers.Add(performer);
                    sb.AppendLine(string.Format(SuccessfullyImportedPerformer,
                        performer.FirstName,
                        performer.PerformerSongs.Count));
                }
            }

            context.Performers.AddRange(performers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}