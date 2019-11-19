using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportOrderItemsDto
    {
        [JsonProperty("Customer")]
        public string CustomerName { get; set; }

        [JsonProperty("Items")]
        public ExportItemDto[] Items { get; set; }

        [JsonProperty("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }
}