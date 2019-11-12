namespace MusicHub.DataProcessor.DTO.ExportDtos
{
    using Newtonsoft.Json;

    public class ExportSongDto
    {
        [JsonProperty("SongName")]
        public string SongName { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Writer")]
        public string Writer { get; set; }
    }
}