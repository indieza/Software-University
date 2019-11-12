namespace MusicHub.DataProcessor.DTO.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDto
    {
        [XmlElement(ElementName = "Name")]
        [MinLength(3), MaxLength(20), Required]
        public string Name { get; set; }

        [XmlElement(ElementName = "Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement(ElementName = "CreatedOn")]
        [Required]
        public string CreatedOn { get; set; }

        [XmlElement(ElementName = "Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement(ElementName = "AlbumId")]
        public int? AlbumId { get; set; }

        [XmlElement(ElementName = "WriterId")]
        [Required]
        public int WriterId { get; set; }

        [XmlElement(ElementName = "Price")]
        [Range(0, 9999.99), Required]
        public decimal Price { get; set; }
    }
}