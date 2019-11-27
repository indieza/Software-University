namespace FastFood.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoryDto
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "MostPopularItem")]
        public ExportMostPopularItemDto MostPopularItem { get; set; }
    }
}