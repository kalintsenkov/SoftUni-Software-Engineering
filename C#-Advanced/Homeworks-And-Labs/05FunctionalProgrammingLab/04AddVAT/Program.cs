using System;
using System.Collections.Generic;
using System.Linq;

namespace _04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> VATNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.20)
                .ToList();

            foreach (var number in VATNumbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
