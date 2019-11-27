namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class ImportOrderDto
    {
        [XmlElement(ElementName = "Customer")]
        [Required]
        public string Customer { get; set; }

        [XmlElement(ElementName = "Employee")]
        [Required]
        public string Employee { get; set; }

        [XmlElement(ElementName = "DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlElement(ElementName = "Type")]
        [Required]
        public string Type { get; set; }

        [XmlArray(ElementName = "Items")]
        public ImportItemToOrderDto[] Items { get; set; }
    }
}