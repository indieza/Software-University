namespace SoftJail.DataProcessor.ExportDto
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExportPrisonerWithOfficersDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CellNumber")]
        public int CellNumber { get; set; }

        [JsonProperty("Officers")]
        public ICollection<ExportOfficerDto> Officers { get; set; }

        [JsonProperty("TotalOfficerSalary")]
        public string TotalOfficerSalary { get; set; }
    }
}