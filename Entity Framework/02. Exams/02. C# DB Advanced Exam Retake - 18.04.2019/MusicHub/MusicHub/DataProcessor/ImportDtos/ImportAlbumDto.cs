using Newtonsoft.Json;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportAlbumDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }
    }
}