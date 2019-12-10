namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage
            = "Invalid data!";
        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";
        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            using var reader = new StringReader(xmlString);

            var xmlSerializer = new XmlSerializer(
                typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));
            var projectsDtos = (ImportProjectDto[])xmlSerializer.Deserialize(reader);

            var projects = new List<Project>();
            var sb = new StringBuilder();

            foreach (var projectDto in projectsDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projectOpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var projectDueDate = GetDueDate(projectDto.DueDate);

                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate
                };

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var taskOpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    var taskDueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (taskOpenDate < projectOpenDate || taskDueDate > projectDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedProject,
                    project.Name,
                    project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            var employees = new List<Employee>();
            var sb = new StringBuilder();

            foreach (var employeeDto in employeesDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Task = task
                    });
                }

                employees.Add(employee);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedEmployee,
                    employee.Username,
                    employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static DateTime? GetDueDate(string dueDate)
        {
            DateTime? date = null;

            if (!string.IsNullOrWhiteSpace(dueDate))
            {
                date = DateTime
                    .ParseExact(dueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            return date;
        }

        private static bool IsValid(object instance)
        {
            var validationContext = new ValidationContext(instance);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(instance, validationContext, validationResults, true);

            return isValid;
        }
    }
}