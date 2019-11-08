namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class ExportCustomerWithCarDto
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}