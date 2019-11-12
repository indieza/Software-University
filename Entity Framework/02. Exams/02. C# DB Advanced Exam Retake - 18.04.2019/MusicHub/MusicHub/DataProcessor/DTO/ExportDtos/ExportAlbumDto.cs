namespace MusicHub.DataProcessor.DTO.ExportDtos
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
        public ICollection<ExportSongDto> Songs { get; set; }

        [JsonProperty("AlbumPrice")]
        public string AlbumPrice { get; set; }
    }
}