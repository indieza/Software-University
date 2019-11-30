using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [XmlElement(ElementName = "ProjectionId")]
        [Required]
        public int ProjectionId { get; set; }

        [XmlElement(ElementName = "Price")]
        [Range(0.01, double.MaxValue), Required]
        public decimal Price { get; set; }
    }
}