namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithTheirListOfPartsDto
    {
        [XmlAttribute(AttributeName = "make")]
        public string Make { get; set; }

        [XmlAttribute(AttributeName = "model")]
        public string Model { get; set; }

        [XmlAttribute(AttributeName = "travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray(ElementName = "parts")]
        public ExportListOfPartsDto[] Parts { get; set; }
    }
}