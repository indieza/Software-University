namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ExportProjectDto
    {
        [XmlAttribute(AttributeName = "TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement(ElementName = "ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement(ElementName = "HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray(ElementName = "Tasks")]
        public ExportProjectTasksDto[] Tasks { get; set; }
    }
}