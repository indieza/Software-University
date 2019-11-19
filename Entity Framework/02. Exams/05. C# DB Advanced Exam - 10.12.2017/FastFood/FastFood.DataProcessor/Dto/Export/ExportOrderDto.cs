namespace FastFood.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;

    public class ExportOrderDto
    {
        [JsonProperty("Name")]
        public string EmployeeName { get; set; }

        [JsonProperty("Orders")]
        public ExportOrderItemsDto[] Orders { get; set; }

        [JsonProperty("TotalMade")]
        public decimal TotalMade { get; set; }
    }
}