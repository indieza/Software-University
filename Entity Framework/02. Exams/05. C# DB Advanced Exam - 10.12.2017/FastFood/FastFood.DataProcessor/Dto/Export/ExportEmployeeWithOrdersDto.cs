namespace FastFood.DataProcessor.Dto.Export
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExportEmployeeWithOrdersDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Orders")]
        public ICollection<ExportOrdersByEmployeeDto> Orders { get; set; }

        [JsonProperty("TotalMade")]
        public decimal TotalMade { get; set; }
    }
}