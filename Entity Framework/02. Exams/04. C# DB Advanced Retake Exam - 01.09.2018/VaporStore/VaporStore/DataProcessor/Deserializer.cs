namespace VaporStore.DataProcessor
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dtos.Import;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string ImportedGame = "Added {0} ({1}) with {2} tags";
        private const string ImportedUser = "Imported {0} with {1} cards";
        private const string ImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            StringBuilder sb = new StringBuilder();

            foreach (var gameDto in gamesDto)
            {
                bool isValidGameDto = IsValid(gameDto);

                if (isValidGameDto == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Developer developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);
                }

                Genre genre = genres.FirstOrDefault(d => d.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                List<Tag> gameTags = new List<Tag>();

                foreach (var tagName in gameDto.Tags)
                {
                    Tag tag = tags.FirstOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };

                        tags.Add(tag);
                    }

                    gameTags.Add(tag);
                }

                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(
                        gameDto.ReleaseDate, @"yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTags.Select(gt => new GameTag { Tag = gt }).ToList()
                };

                games.Add(game);

                sb.AppendLine(string.Format(ImportedGame,
                    game.Name,
                    game.Genre.Name,
                    game.GameTags.Count()));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            List<User> users = new List<User>();

            StringBuilder sb = new StringBuilder();

            foreach (var userDto in usersDto)
            {
                User user = Mapper.Map<User>(userDto);

                bool isValidUser = IsValid(user);
                bool isInvalidCards = user.Cards.Any(c => IsValid(c) == false) || user.Cards.Count == 0;

                if (isValidUser == false || isInvalidCards == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                users.Add(user);

                sb.AppendLine(string.Format(ImportedUser,
                    user.Username,
                    user.Cards.Count));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                bool isValidDto = IsValid(purchaseDto);
                bool isValidType = Enum.IsDefined(typeof(PurchaseType), purchaseDto.Type);
                var targetGame = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);
                var targtCard = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card);

                if (isValidDto == false ||
                    isValidType == false ||
                    targetGame == null ||
                    targtCard == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Card = targtCard,
                    Game = targetGame,
                    Date = DateTime.ParseExact(
                        purchaseDto.Date, @"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    ProductKey = purchaseDto.Key,
                    Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchaseDto.Type)
                };

                purchases.Add(purchase);

                sb.AppendLine(string.Format(ImportedPurchase,
                    purchase.Game.Name,
                    purchase.Card.User.Username));
            }

            context.Purchases.AddRange(purchases);
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