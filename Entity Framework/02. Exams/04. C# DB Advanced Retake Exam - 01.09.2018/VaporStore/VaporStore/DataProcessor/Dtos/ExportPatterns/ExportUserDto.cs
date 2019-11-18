namespace VaporStore.DataProcessor.Dtos.ExportPatterns
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ExportUserDto
    {
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

        [XmlArray(ElementName = "Purchases")]
        public ExportPurchaseDto[] Purchases { get; set; }

        [XmlElement(ElementName = "TotalSpent")]
        public decimal TotalSpent { get; set; }
    }
}