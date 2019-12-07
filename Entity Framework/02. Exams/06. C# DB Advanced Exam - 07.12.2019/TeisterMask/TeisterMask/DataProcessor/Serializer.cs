namespace TeisterMask.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ExportProjectDto
                {
                    TaskCount = p.Tasks.Count,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    ProjectName = p.Name,
                    Tasks = p.Tasks.Select(t => new ExportProjectTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.TaskCount)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), new XmlRootAttribute("Projects"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), projects, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var emplyees = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .OrderByDescending(e => e.EmployeesTasks.Count(t => t.Task.OpenDate >= date))
                .ThenBy(e => e.Username)
                .Select(e => new ExportEmployeeDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .Select(t => new ExportTaskDto
                    {
                        TaskName = t.Task.Name,
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString(),
                        DueDate = t.Task.DueDate.ToString(@"d", CultureInfo.InvariantCulture),
                        OpenDate = t.Task.OpenDate.ToString(@"d", CultureInfo.InvariantCulture)
                    })
                    .OrderByDescending(t => DateTime.ParseExact(t.DueDate, @"d", CultureInfo.InvariantCulture))
                    .ThenBy(t => t.TaskName)
                    .ToList()
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(emplyees, Formatting.Indented);

            return json;
        }
    }
}