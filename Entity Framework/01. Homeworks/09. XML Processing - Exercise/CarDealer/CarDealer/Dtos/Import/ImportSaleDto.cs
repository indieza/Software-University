namespace CarDealer.Dtos.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Sale")]
    public class ImportSaleDto
    {
        [XmlElement(ElementName = "carId")]
        public int CarId { get; set; }

        [XmlElement(ElementName = "customerId")]
        public int CustomerId { get; set; }

        [XmlElement(ElementName = "discount")]
        public decimal Discount { get; set; }
    }
}