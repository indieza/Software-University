namespace VaporStore.DataProcessor.Dtos.Import
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportGameDto
    {
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("Price")]
        [Range(0, double.MaxValue), Required]
        public decimal Price { get; set; }

        [JsonProperty("ReleaseDate")]
        [Required]
        public string ReleaseDate { get; set; }

        [JsonProperty("Developer")]
        [Required]
        public string Developer { get; set; }

        [JsonProperty("Genre")]
        [Required]
        public string Genre { get; set; }

        [JsonProperty("Tags")]
        [MinLength(1)]
        public ICollection<string> Tags { get; set; }
    }
}