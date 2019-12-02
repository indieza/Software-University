namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using System.Collections.Generic;

    public class ImportDepartmentDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Cells")]
        public ICollection<Cell> Cells { get; set; }
    }
}