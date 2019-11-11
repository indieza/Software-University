namespace CarDealer.Dtos.Import
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class ImportCustomerDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement(ElementName = "isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}