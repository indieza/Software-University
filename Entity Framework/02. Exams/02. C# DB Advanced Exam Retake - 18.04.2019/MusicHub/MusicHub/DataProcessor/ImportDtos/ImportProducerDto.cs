namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Collections.Generic;

    public class ImportProducerDto
    {
        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<ImportAlbumDto> Albums { get; set; }
    }
}