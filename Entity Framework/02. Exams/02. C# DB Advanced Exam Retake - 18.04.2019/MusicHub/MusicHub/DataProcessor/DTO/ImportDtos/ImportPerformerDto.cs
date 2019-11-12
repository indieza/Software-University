namespace MusicHub.DataProcessor.DTO.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        [XmlElement(ElementName = "FirstName")]
        [MinLength(3), MaxLength(20), Required]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        [MinLength(3), MaxLength(20), Required]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Age")]
        [Range(18, 70), Required]
        public int Age { get; set; }

        [XmlElement(ElementName = "NetWorth")]
        [Range(0, 9999.99), Required]
        public decimal NetWorth { get; set; }

        [XmlArray(ElementName = "PerformersSongs")]
        public ImportPerformerSongsDto[] PerformersSongs { get; set; }
    }
}