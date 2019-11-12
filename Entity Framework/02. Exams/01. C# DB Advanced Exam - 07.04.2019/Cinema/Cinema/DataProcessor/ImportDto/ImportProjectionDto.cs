namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [XmlElement(ElementName = "MovieId")]
        [Required]
        public int MovieId { get; set; }

        [XmlElement(ElementName = "HallId")]
        [Required]
        public int HallId { get; set; }

        [XmlElement(ElementName = "DateTime")]
        [Required]
        public string DateTime { get; set; }
    }
}