using System;
using System.Linq;
using System.Collections.Generic;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            foreach (var divider in dividers)
            {
                Func<int, bool> filterFunc = x => x % divider == 0;

                numbers = numbers.Where(filterFunc).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
