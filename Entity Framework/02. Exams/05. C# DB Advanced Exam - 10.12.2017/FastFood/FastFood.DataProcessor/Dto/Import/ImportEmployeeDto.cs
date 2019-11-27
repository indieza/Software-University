namespace FastFood.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportEmployeeDto
    {
        [JsonProperty("Name")]
        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [JsonProperty("Age")]
        [Range(15, 80), Required]
        public int Age { get; set; }

        [JsonProperty("Position")]
        [MinLength(3), MaxLength(30), Required]
        public string Position { get; set; }
    }
}