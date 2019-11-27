using Newtonsoft.Json;
using System.Collections.Generic;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportOrdersByEmployeeDto
    {
        [JsonProperty("Customer")]
        public string Customer { get; set; }

        [JsonProperty("Items")]
        public ICollection<ExportItemsForOrderDto> Items { get; set; }

        [JsonProperty("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }
}