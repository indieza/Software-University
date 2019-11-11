namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "parts")]
    public class ImportPartsIdDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int PartId { get; set; }
    }
}