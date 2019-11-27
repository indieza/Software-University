namespace FastFood.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportItemDto
    {
        [JsonProperty("Name")]
        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Range(0.01, double.MaxValue), Required]
        public decimal Price { get; set; }

        [JsonProperty("Category")]
        [MinLength(3), MaxLength(30), Required]
        public string Category { get; set; }
    }
}