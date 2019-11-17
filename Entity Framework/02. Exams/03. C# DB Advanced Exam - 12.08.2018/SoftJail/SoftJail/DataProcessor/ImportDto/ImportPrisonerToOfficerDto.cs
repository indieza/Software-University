using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportPrisonerToOfficerDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}