namespace FastFood.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        [JsonProperty("Position")]
        [MinLength(3), MaxLength(30), Required]
        public string PositionName { get; set; }
    }
}