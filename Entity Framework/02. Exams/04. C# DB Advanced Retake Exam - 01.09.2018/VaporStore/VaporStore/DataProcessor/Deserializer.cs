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
    using VaporStore.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullyAddedGame = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullyAddedUser = "Imported {0} with {1} cards";
        private const string SuccessfullyAddedPurchase = "Imported {0} for {1}";

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
                if (IsValid(gameDto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var developer = developers.FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);
                }

                var genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

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
                    var tag = tags.FirstOrDefault(t => t.Name == tagName);

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
                        gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTags.Select(t => new GameTag { Tag = t }).ToList()
                };

                games.Add(game);

                sb.AppendLine(string.Format(SuccessfullyAddedGame,
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
                bool correctCardsType = userDto.Cards.Any(c => !Enum.IsDefined(typeof(CardType), c.Type));

                if (correctCardsType == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = Mapper.Map<User>(userDto);

                bool isValidUser = IsValid(user);
                bool hasCards = userDto.Cards.Count > 0;
                bool isValidCards = user.Cards.Any(c => !IsValid(c));

                if (isValidUser == false || hasCards == false || isValidCards == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                users.Add(user);

                sb.AppendLine(string.Format(SuccessfullyAddedUser, user.Username, user.Cards.Count()));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            var purchesesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();

            foreach (var purchesDto in purchesesDto)
            {
                bool isValidPurches = IsValid(purchesDto);
                bool isCorrectType = Enum.IsDefined(typeof(PurchaseType), purchesDto.Type);
                Game targetGame = context.Games.FirstOrDefault(g => g.Name == purchesDto.Title);
                Card targetCard = context.Cards.FirstOrDefault(c => c.Number == purchesDto.Card);

                if (isValidPurches == false ||
                    isCorrectType == false ||
                    targetGame == null ||
                    targetCard == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Card = targetCard,
                    CardId = targetCard.Id,
                    Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchesDto.Type),
                    Date = DateTime.ParseExact(
                        purchesDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Game = targetGame,
                    GameId = targetGame.Id,
                    ProductKey = purchesDto.Key
                };

                purchases.Add(purchase);

                sb.AppendLine(string.Format(SuccessfullyAddedPurchase,
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