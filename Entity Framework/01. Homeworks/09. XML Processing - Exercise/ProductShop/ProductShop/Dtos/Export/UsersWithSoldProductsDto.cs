namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UsersWithSoldProductsDto
    {
        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "age")]
        public int? Age { get; set; }

        [XmlElement(ElementName = "SoldProducts")]
        public SoldProductsCountDto SoldProducts { get; set; }
    }
}