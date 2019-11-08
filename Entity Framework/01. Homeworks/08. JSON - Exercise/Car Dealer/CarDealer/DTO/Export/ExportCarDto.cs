namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class ExportCarDto
    {
        [JsonProperty("Make")]
        public string Make { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("TravelledDistance")]
        public long TravelledDistance { get; set; }
    }
}