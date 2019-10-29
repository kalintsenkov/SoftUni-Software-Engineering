namespace _08AddressesByTown
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
                var result = GetAddressesByTown(context);

                Console.WriteLine(result);
            }
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    Text = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.Text)
                .Take(10)
                .ToList();

            var result = new StringBuilder();

            foreach (var address in addresses)
            {
                result.AppendLine($"{address.Text}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return result.ToString().TrimEnd();
        }
    }
}
