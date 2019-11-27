using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportItemsForOrderDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }
    }
}