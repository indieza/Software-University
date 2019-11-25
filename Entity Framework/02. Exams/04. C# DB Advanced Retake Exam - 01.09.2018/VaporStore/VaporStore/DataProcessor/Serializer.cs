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
    using VaporStore.DataProcessor.Dtos.Export;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .OrderByDescending(g => g.Games
                .Where(game => game.Purchases.Count >= 1)
                .Sum(s => s.Purchases.Count))
                .ThenBy(g => g.Id)
                .Select(genre => new ExportGenreInRangeDto
                {
                    Id = genre.Id,
                    Genre = genre.Name,
                    Games = genre.Games
                    .Where(game => game.Purchases.Count >= 1)
                    .Select(game => new ExportGameByGenreDto
                    {
                        Id = game.Id,
                        Developer = game.Developer.Name,
                        Title = game.Name,
                        Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name)),
                        Players = game.Purchases.Count
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToList(),
                    TotalPlayers = genre.Games
                    .Where(game => game.Purchases.Count >= 1)
                    .Sum(g => g.Purchases.Count)
                })
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
                    Purchases = user.Cards.SelectMany(p => p.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new ExportPurchaseByTypeDto
                    {
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString(@"yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Card = p.Card.Number,
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = user.Cards.SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Sum(p => p.Game.Price)
                })
                .Where(p => p.Purchases.Any())
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