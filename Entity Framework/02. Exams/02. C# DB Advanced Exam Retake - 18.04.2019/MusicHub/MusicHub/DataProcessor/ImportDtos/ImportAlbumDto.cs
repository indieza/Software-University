using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportAlbumDto
    {
        [JsonProperty("Name")]
        [MinLength(3), MaxLength(40), Required]
        public string Name { get; set; }

        [JsonProperty("ReleaseDate")]
        [Required]
        public string ReleaseDate { get; set; }
    }
}