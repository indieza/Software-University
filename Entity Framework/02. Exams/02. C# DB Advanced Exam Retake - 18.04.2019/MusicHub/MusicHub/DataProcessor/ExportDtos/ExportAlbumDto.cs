namespace MusicHub.DataProcessor.ExportDtos
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExportAlbumDto
    {
        [JsonProperty("AlbumName")]
        public string AlbumName { get; set; }

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("ProducerName")]
        public string ProducerName { get; set; }

        [JsonProperty("Songs")]
        public ICollection<ExportSongForAlbumDto> Songs { get; set; }

        [JsonProperty("AlbumPrice")]
        public string AlbumPrice { get; set; }
    }
}