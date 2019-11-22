namespace MusicHub.DataProcessor.ImportDtos
{
    using Newtonsoft.Json;

    public class ImportWriterDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Pseudonym")]
        public string Pseudonym { get; set; }
    }
}