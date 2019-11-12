namespace MusicHub.DataProcessor.DTO.ExportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ExportSongAboveDuration
    {
        [XmlElement(ElementName = "SongName")]
        public string SongName { get; set; }

        [XmlElement(ElementName = "Writer")]
        public string Writer { get; set; }

        [XmlElement(ElementName = "Performer")]
        public string Performer { get; set; }

        [XmlElement(ElementName = "AlbumProducer")]
        public string AlbumProducer { get; set; }

        [XmlElement(ElementName = "Duration")]
        public string Duration { get; set; }
    }
}