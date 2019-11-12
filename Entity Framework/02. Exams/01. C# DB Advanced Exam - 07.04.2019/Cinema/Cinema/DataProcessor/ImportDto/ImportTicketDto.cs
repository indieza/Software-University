using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [Required]
        [XmlElement(ElementName = "ProjectionId")]
        public int ProjectionId { get; set; }

        [Required]
        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
    }
}