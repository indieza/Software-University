using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportOfficersInRangeDto
    {
        [JsonProperty("OfficerName")]
        public string OfficerName { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }
    }
}