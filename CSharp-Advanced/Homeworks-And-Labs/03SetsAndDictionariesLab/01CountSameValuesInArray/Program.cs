using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dict = new Dictionary<double, int>();

            foreach (var value in values)
            {
                if (!dict.ContainsKey(value))
                {
                    dict[value] = 1;
                }
                else
                {
                    dict[value]++;
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
