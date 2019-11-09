namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ImportCategoryDto
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}