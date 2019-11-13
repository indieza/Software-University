namespace SoftJail.DataProcessor.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Prisoner")]
    public class ExportPrisonerDto
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlElement(ElementName = "EncryptedMessages")]
        public ExportMailDto[] EncryptedMessages { get; set; }
    }
}