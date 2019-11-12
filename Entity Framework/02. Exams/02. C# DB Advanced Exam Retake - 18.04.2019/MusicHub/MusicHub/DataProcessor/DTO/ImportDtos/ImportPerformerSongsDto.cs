namespace MusicHub.DataProcessor.DTO.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportPerformerSongsDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}