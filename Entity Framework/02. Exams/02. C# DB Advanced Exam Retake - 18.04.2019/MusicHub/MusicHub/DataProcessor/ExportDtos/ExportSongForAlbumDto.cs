namespace MusicHub.DataProcessor.ExportDtos
{
    using Newtonsoft.Json;

    public class ExportSongForAlbumDto
    {
        [JsonProperty("SongName")]
        public string SongName { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }

        [JsonProperty("Writer")]
        public string Writer { get; set; }
    }
}