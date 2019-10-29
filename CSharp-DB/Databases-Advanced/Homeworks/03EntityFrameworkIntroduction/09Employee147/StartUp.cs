namespace _09Employee147
{
    using System;
    using System.Linq;
    using System.Text;

    using SoftUni.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var result = GetEmployee147(context);

                Console.WriteLine(result);
            }
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(p => p.Project.Name)
                        .OrderBy(p => p)
                })
                .FirstOrDefault();

            var result = new StringBuilder();

            result.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                result.AppendLine(project);
            }

            return result.ToString().TrimEnd();
        }
    }
}
