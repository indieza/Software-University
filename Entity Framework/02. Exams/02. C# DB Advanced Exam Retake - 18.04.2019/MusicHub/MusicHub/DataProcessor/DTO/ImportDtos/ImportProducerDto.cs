namespace MusicHub.DataProcessor.DTO.ImportDtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportProducerDto
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 [0-9]{3} [0-9]{3} [0-9]{3}$")]
        public string PhoneNumber { get; set; }

        public ICollection<ImportAlbumDto> Albums { get; set; }
    }
}