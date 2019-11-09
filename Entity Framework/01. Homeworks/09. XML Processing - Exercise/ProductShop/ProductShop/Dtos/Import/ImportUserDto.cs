namespace ProductShop.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class ImportUserDto
    {
        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }
    }
}