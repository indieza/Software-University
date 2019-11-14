namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Xml;
    using VaporStore.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .Select(genre => new ExportGenreDto
                {
                    Id = genre.Id,
                    Genre = genre.Name,
                    Games = genre.Games
                    .Where(g => g.Purchases.Count >= 1)
                    .Select(game => new ExportGameDto
                    {
                        Id = game.Id,
                        Title = game.Name,
                        Developer = game.Developer.Name,
                        Tags = string.Join(", ", game.GameTags.Select(t => t.Tag.Name)),
                        Players = game.Purchases.Count()
                    })
                    .OrderByDescending(game => game.Players)
                    .ThenBy(game => game.Id)
                    .ToList(),
                    TotalPlayers = genre.Games.Sum(g => g.Purchases.Count)
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            throw new NotImplementedException();
        }
    }
}