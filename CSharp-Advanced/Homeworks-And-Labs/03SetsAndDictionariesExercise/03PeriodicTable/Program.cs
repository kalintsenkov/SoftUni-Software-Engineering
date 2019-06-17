using System;
using System.Collections.Generic;
using System.Linq;

namespace _03PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var uniqueChemicals = new HashSet<string>();

            for (int i = 0; i < numberOfLines; i++)
            {
                var chemicals = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var chemical in chemicals)
                {
                    uniqueChemicals.Add(chemical);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueChemicals.OrderBy(x => x)));
        }
    }
}
