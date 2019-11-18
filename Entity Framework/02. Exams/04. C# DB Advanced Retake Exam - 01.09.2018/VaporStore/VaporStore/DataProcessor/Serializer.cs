namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using VaporStore.DataProcessor.Dtos.ExportPatterns;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(genre => genreNames.Contains(genre.Name))
                .Select(g => new ExportGenreInRangeDto
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Where(x => x.Purchases.Count >= 1)
                    .Select(game => new ExportGameInRangeDto
                    {
                        Id = game.Id,
                        Developer = game.Developer.Name,
                        Title = game.Name,
                        Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name)),
                        Players = game.Purchases.Count()
                    })
                    .OrderByDescending(t => t.Players)
                    .ThenBy(t => t.Id)
                    .ToList(),
                    TotalPlayers = g.Games.Sum(t => t.Purchases.Count())
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .Select(user => new ExportUserDto
                {
                    Username = user.Username,
                    Purchases = user.Cards
                    .SelectMany(card => card.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new ExportPurchaseDto
                    {
                        Cvc = p.Card.Cvc,
                        Card = p.Card.Number,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = user.Cards
                    .SelectMany(card => card.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Sum(purchase => purchase.Game.Price)
                })
                .Where(user => user.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}