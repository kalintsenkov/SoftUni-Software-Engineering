namespace _04EmployeesWithSalaryOver50000
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
                var result = GetEmployeesWithSalaryOver50000(context);

                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            var result = new StringBuilder();

            foreach (var emp in employees)
            {
                result.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
