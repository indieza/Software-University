using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dtos.ExportPatterns
{
    [XmlType("Game")]
    public class ExportGameDto
    {
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "Genre")]
        public string Genre { get; set; }

        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
    }
}