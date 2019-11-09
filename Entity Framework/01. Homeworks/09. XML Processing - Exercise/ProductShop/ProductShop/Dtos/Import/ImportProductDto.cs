namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Product")]
    public class ImportProductDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "sellerId")]
        public int SellerId { get; set; }

        [XmlElement(ElementName = "buyerId")]
        public int? BuyerId { get; set; }
    }
}