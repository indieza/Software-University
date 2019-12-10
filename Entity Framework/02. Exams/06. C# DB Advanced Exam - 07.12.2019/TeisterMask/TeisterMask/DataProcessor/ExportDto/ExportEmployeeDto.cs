namespace TeisterMask.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExportEmployeeDto
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Tasks")]
        public ICollection<ExportEmployeeTasksDto> Tasks { get; set; }
    }
}