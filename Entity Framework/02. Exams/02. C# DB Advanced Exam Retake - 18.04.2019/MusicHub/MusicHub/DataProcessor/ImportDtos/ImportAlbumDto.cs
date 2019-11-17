using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportAlbumDto
    {
        [MinLength(3), MaxLength(40), Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}