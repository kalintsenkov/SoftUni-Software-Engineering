namespace _10DepartmentsWithMoreThan5Employees
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
                var result = GetDepartmentsWithMoreThan5Employees(context);

                Console.WriteLine(result);
            }
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstname = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var dep in departments)
            {
                result.AppendLine($"{dep.Name} - {dep.ManagerFirstname} {dep.ManagerLastName}");

                foreach (var emp in dep.Employees)
                {
                    result.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
