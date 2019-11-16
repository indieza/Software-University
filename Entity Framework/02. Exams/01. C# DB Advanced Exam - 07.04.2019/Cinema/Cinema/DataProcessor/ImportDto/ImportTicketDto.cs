using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [XmlElement(ElementName = "ProjectionId")]
        public int ProjectionId { get; set; }

        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
    }
}