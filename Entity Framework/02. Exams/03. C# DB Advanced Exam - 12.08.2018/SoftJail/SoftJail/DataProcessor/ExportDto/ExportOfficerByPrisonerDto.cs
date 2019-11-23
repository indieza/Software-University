using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportOfficerByPrisonerDto
    {
        [JsonProperty("OfficerName")]
        public string OfficerName { get; set; }

        [JsonProperty("Department")]
        public string Department { get; set; }
    }
}