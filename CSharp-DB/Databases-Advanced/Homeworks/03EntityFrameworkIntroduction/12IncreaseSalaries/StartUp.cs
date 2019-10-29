namespace _12IncreaseSalaries
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
                var result = IncreaseSalaries(context);

                Console.WriteLine(result);
            }
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary += emp.Salary * 0.12M;
            }

            context.SaveChanges();

            var updatedEmployees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var result = new StringBuilder();

            foreach (var emp in updatedEmployees)
            {
                result.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return result.ToString().TrimEnd();
        }
    }
}
