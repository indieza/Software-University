using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectDto
    {
        [XmlElement(ElementName = "Name")]
        [MinLength(2), MaxLength(40), Required]
        public string Name { get; set; }

        [XmlElement(ElementName = "OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement(ElementName = "DueDate")]
        public string DueDate { get; set; }

        [XmlArray(ElementName = "Tasks")]
        public ImportTaskDto[] Tasks { get; set; }
    }
}