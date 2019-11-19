namespace FastFood.DataProcessor.Dto.Import
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ImportItemDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        [JsonProperty("Category")]
        [MinLength(3), MaxLength(30), Required]
        public string CategoryName { get; set; }
    }
}