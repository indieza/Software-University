using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportPrisonerIds
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}