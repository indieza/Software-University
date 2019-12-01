namespace MusicHub.DataProcessor.ImportDtos
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ImportProducerDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Pseudonym")]
        public string Pseudonym { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public ICollection<ImportAlbumDto> ProducerAlbums { get; set; }
    }
}