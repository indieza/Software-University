namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ImportCategoryDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }
}