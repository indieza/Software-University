namespace TeisterMask.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(
                typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));
            var projectsDto = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Project> projects = new List<Project>();

            StringBuilder sb = new StringBuilder();

            foreach (var projectDto in projectsDto)
            {
                bool isValidProjectDto = IsValid(projectDto);

                if (isValidProjectDto == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(
                        projectDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = string.IsNullOrEmpty(projectDto.DueDate) ?
                        (DateTime?)null
                        : DateTime.ParseExact(
                        projectDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    bool isValidTask = IsValid(taskDto);
                    bool isValidExecutionType = Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType);
                    bool isValidLabelType = Enum.IsDefined(typeof(LabelType), taskDto.LabelType);

                    if (isValidTask == false || isValidExecutionType == false || isValidLabelType == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate = DateTime.ParseExact(
                            taskDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime projectOpenDate = project.OpenDate;

                    DateTime taskDueDate = DateTime.ParseExact(
                            taskDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime? projectDueDate = project.DueDate;

                    if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)
                            Enum.ToObject(typeof(ExecutionType), taskDto.ExecutionType),
                        LabelType = (LabelType)
                            Enum.ToObject(typeof(LabelType), taskDto.LabelType),
                        Project = project
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject,
                    project.Name,
                    project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> employees = new List<Employee>();

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in employeesDto)
            {
                bool isValidEmployee = IsValid(employeeDto);

                if (isValidEmployee == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    if (context.Tasks.Find(taskId) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { TaskId = taskId });
                }

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee,
                    employee.Username,
                    employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}