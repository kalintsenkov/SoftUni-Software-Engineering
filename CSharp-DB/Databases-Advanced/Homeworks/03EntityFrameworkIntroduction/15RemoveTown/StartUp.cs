namespace _15RemoveTown
{
    using System;
    using System.Linq;

    using SoftUni.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var result = RemoveTown(context);

                Console.WriteLine(result);
            }
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var addressIdsToRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .Select(a => a.AddressId)
                .ToList();

            var employees = context.Employees
                .ToList();

            foreach (var id in addressIdsToRemove)
            {
                foreach (var emp in employees)
                {
                    emp.AddressId = null;
                }
            }

            var addressesToRemove = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            foreach (var address in addressesToRemove)
            {
                context.Addresses.Remove(address);
            }

            var townToRemove = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{addressesToRemove.Count} addresses in Seattle were deleted";
        }
    }
}
