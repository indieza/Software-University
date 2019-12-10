using Newtonsoft.Json;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeTasksDto
    {
        [JsonProperty("TaskName")]
        public string TaskName { get; set; }

        [JsonProperty("OpenDate")]
        public string OpenDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("LabelType")]
        public string LabelType { get; set; }

        [JsonProperty("ExecutionType")]
        public string ExecutionType { get; set; }
    }
}