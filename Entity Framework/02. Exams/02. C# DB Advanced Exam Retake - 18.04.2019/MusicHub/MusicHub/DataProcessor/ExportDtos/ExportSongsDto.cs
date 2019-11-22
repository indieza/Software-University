using Newtonsoft.Json;

namespace MusicHub.DataProcessor.ExportDtos
{
    public class ExportSongsDto
    {
        [JsonProperty("SongName")]
        public string SongName { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Writer")]
        public string Writer { get; set; }
    }
}