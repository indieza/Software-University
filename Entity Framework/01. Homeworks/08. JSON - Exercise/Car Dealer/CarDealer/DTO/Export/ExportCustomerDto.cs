namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class ExportCustomerDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}