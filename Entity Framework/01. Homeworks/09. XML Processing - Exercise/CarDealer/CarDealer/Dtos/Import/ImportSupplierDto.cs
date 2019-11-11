namespace CarDealer.Dtos.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Supplier")]
    public class ImportSupplierDto
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "isImporter")]
        public bool IsImporter { get; set; }
    }
}