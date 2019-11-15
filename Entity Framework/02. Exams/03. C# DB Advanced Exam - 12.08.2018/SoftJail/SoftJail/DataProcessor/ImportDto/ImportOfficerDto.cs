namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Officer")]
    public class ImportOfficerDto
    {
        [XmlElement(ElementName = "Name")]
        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [XmlElement(ElementName = "Money")]
        [Range(0, double.MaxValue), Required]
        public decimal Money { get; set; }

        [XmlElement(ElementName = "Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement(ElementName = "Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement(ElementName = "DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray(ElementName = "Prisoners")]
        public ImportPrisonerIds[] Prisoners { get; set; }
    }
}