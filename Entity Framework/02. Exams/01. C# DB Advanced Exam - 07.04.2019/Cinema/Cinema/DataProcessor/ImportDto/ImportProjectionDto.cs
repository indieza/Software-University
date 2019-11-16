namespace Cinema.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [XmlElement(ElementName = "MovieId")]
        public int MovieId { get; set; }

        [XmlElement(ElementName = "HallId")]
        public int HallId { get; set; }

        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }
    }
}