namespace CarDealer.Dtos.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "parts")]
    public class ImportPartsIdDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int PartId { get; set; }
    }
}