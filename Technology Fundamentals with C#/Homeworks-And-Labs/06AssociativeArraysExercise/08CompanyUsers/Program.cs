using System;
using System.Linq;
using System.Collections.Generic;

namespace _08CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string companyName = tokens[0];
                string employeeId = tokens[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }

                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var employee in kvp.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
