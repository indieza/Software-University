namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class ImportCategoryProductsDto
    {
        [XmlElement(ElementName = "CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement(ElementName = "ProductId")]
        public int ProductId { get; set; }
    }
}