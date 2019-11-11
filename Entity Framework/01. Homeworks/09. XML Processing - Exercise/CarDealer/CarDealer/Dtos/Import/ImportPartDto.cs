namespace CarDealer.Dtos.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Part")]
    public class ImportPartDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal Price { get; set; }

        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "supplierId")]
        public int SupplierId { get; set; }
    }
}