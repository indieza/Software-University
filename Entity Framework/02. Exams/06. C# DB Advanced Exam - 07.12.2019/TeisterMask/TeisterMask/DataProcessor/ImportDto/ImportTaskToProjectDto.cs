using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskToProjectDto
    {
        [XmlElement(ElementName = "Name")]
        [MinLength(2), MaxLength(40), Required]
        public string Name { get; set; }

        [XmlElement(ElementName = "OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement(ElementName = "DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement(ElementName = "ExecutionType")]
        [Required]
        public int ExecutionType { get; set; }

        [XmlElement(ElementName = "LabelType")]
        [Required]
        public int LabelType { get; set; }
    }
}