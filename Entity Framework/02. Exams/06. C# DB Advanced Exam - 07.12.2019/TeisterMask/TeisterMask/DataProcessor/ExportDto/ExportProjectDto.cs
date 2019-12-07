using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlAttribute(AttributeName = "TasksCount")]
        public int TaskCount { get; set; }

        [XmlElement(ElementName = "ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement(ElementName = "HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray(ElementName = "Tasks")]
        public ExportProjectTaskDto[] Tasks { get; set; }
    }
}