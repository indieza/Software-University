namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Performer")]
    public class ImportPerformerDto
    {
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "Age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "NetWorth")]
        public decimal NetWorth { get; set; }

        [XmlArray(ElementName = "PerformersSongs")]
        public ImportPerformersSongsDto[] PerformersSongs { get; set; }
    }
}