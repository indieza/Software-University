namespace Cinema.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement(ElementName = "FirstName")]
        [MinLength(3), MaxLength(20), Required]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        [MinLength(3), MaxLength(20), Required]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Age")]
        [Range(12, 110), Required]
        public int Age { get; set; }

        [XmlElement(ElementName = "Balance")]
        [Range(0.01, 999999.99), Required]
        public decimal Balance { get; set; }

        [XmlArray(ElementName = "Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}