namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [XmlElement(ElementName = "Name")]
        public string FullName { get; set; }

        [XmlElement(ElementName = "Money")]
        public decimal Salary { get; set; }

        [XmlElement(ElementName = "Position")]
        public string Position { get; set; }

        [XmlElement(ElementName = "Weapon")]
        public string Weapon { get; set; }

        [XmlElement(ElementName = "DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray(ElementName = "Prisoners")]
        public ImportPrisonerId[] Prisoners { get; set; }
    }
}