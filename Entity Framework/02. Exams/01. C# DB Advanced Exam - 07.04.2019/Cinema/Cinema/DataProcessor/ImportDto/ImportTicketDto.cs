namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class ImportTicketDto
    {
        [XmlElement(ElementName = "ProjectionId")]
        public int ProjectionId { get; set; }

        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
    }
}