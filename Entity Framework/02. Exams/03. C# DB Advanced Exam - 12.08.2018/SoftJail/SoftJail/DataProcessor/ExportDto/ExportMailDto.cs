using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class ExportMailDto
    {
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }
}