namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class ExportPartDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public string Price { get; set; }
    }
}