namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class ImportSongDto
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Duration")]
        public string Duration { get; set; }

        [XmlElement(ElementName = "CreatedOn")]
        public string CreatedOn { get; set; }

        [XmlElement(ElementName = "Genre")]
        public string Genre { get; set; }

        [XmlElement(ElementName = "AlbumId")]
        public int? AlbumId { get; set; }

        [XmlElement(ElementName = "WriterId")]
        public int WriterId { get; set; }

        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
    }
}