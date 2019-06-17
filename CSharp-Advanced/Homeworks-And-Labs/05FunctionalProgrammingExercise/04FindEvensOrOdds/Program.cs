using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();

            Func<int, bool> filterFunc = GetFilter(command);

            List<int> result = numbers
                .Where(filterFunc)
                .ToList();

            Console.WriteLine(string.Join(" ", result));
        }

        private static Func<int, bool> GetFilter(string command)
        {
            if (command == "odd")
            {
                return x => x % 2 != 0;
            }
            else if (command == "even")
            {
                return x => x % 2 == 0;
            }
            else
            {
                return x => true;
            }
        }
    }
}
