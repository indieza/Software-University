namespace CarDealer.Dtos.Import
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class ImportCarDto
    {
        [XmlElement(ElementName = "make")]
        public string Make { get; set; }

        [XmlElement(ElementName = "model")]
        public string Model { get; set; }

        [XmlElement(ElementName = "TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlElement(ElementName = "parts")]
        public ImportPartsDto Parts { get; set; }
    }
}