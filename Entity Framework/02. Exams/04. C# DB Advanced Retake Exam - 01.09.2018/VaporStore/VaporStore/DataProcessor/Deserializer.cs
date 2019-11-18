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
    using VaporStore.DataProcessor.Dtos.ImportPatterns;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullAddedGame = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullAddedUserWithCards = "Imported {0} with {1} cards";
        private const string SuccessfullAddedPurchase = "Imported {0} for {1}";

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
                bool isValidTags = gameDto.Tags.Any(t => IsValid(t) == false);

                if (isValidGameDto == false || isValidTags == true)
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

                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

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
                    }

                    tags.Add(tag);
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

                sb.AppendLine(string.Format(SuccessfullAddedGame,
                    game.Name,
                    game.Genre.Name,
                    gameTags.Count()));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUserWithCardsDto[]>(jsonString);

            List<User> users = new List<User>();

            StringBuilder sb = new StringBuilder();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                bool isValidUser = IsValid(user);
                bool hasAnyCards = userDto.UserCards.Count > 0;
                bool isValidCards = userDto.UserCards.Any(c => IsValid(c) == false);

                if (isValidUser == false || hasAnyCards == false || isValidCards == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var cardDto in userDto.UserCards)
                {
                    var card = Mapper.Map<Card>(cardDto);
                    user.Cards.Add(card);
                }

                users.Add(user);

                sb.AppendLine(string.Format(SuccessfullAddedUserWithCards,
                    user.Username,
                    user.Cards.Count()));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(
                typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                var purchase = Mapper.Map<Purchase>(purchaseDto);
                bool isValidPurchase = IsValid(purchase);
                Card targetCard = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber);
                Game targetGame = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (isValidPurchase == false || targetCard == null || targetGame == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                purchase.Card = targetCard;
                purchase.Game = targetGame;

                User targetUser = context.Users.FirstOrDefault(u => u.Id == targetCard.UserId);
                purchases.Add(purchase);

                sb.AppendLine(string.Format(SuccessfullAddedPurchase,
                    targetGame.Name,
                    targetUser.Username));
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