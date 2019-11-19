namespace FastFood.DataProcessor.Dto.Import
{
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class ImportOrderDto
    {
        public string Customer { get; set; }

        [XmlElement(ElementName = "Employee")]
        public string EmployeeName { get; set; }

        public string DateTime { get; set; }

        public string Type { get; set; }

        [XmlArray(ElementName = "Items")]
        public ImportItemToOrderDto[] Items { get; set; }
    }
}