namespace _06AddingNewAddressAndUpdatingEmployee
{
    using System;
    using System.Linq;
    using System.Text;

    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var result = AddNewAddressToEmployee(context);

                Console.WriteLine(result);
            }
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            address.Employees.Add(employee);

            employee.Address = address;

            context.SaveChanges();

            var employeesAddresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToList();

            var result = new StringBuilder();

            foreach (var addr in employeesAddresses)
            {
                result.AppendLine(addr);
            }

            return result.ToString().TrimEnd();
        }
    }
}
