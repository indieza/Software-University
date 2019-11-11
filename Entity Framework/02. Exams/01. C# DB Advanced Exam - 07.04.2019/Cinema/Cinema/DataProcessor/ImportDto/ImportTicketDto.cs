namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [XmlElement(ElementName = "ProjectionId")]
        public int ProjectionId { get; set; }

        [XmlElement(ElementName = "Price")]
        [Range(0.01, 99999.99), Required]
        public decimal Price { get; set; }
    }
}