namespace VaporStore.DataProcessor.Dtos.Export
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExportGenreInRangeDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Games")]
        public ICollection<ExportGameByGenreDto> Games { get; set; }

        [JsonProperty("TotalPlayers")]
        public int TotalPlayers { get; set; }
    }
}