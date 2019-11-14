namespace VaporStore.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute(AttributeName = "title")]
        [Required]
        public string Title { get; set; }

        [XmlElement(ElementName = "Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement(ElementName = "Key")]
        [RegularExpression(@"^[0-9A-Z]{4}-[0-9A-Z]{4}-[0-9A-Z]{4}$"), Required]
        public string Key { get; set; }

        [XmlElement(ElementName = "Card")]
        [Required]
        public string Card { get; set; }

        [XmlElement(ElementName = "Date")]
        [Required]
        public string Date { get; set; }
    }
}