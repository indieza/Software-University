namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSaleWithAppliedDiscountDto
    {
        [XmlElement(ElementName = "car")]
        public ExportCarDto Car { get; set; }

        [XmlElement(ElementName = "discount")]
        public decimal Discount { get; set; }

        [XmlElement(ElementName = "customer-name")]
        public string CustomerName { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}