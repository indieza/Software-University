using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ExportDto
{
    public class ExportGameDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Developer")]
        public string Developer { get; set; }

        [JsonProperty("Tags")]
        public string Tags { get; set; }

        [JsonProperty("Players")]
        public int Players { get; set; }
    }
}