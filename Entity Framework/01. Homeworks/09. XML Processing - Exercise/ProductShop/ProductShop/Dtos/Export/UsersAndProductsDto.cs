namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class UsersAndProductsDto
    {
        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlArray(ElementName = "users")]
        public UsersWithSoldProductsDto[] Users { get; set; }
    }
}