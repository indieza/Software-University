namespace MusicHub.DataProcessor.DTO.ImportDtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ImportAlbumDto
    {
        [MinLength(3), MaxLength(40), Required]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}