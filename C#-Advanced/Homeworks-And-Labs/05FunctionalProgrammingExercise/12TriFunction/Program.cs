using System;
using System.Collections.Generic;
using System.Linq;

namespace _12TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(names
                .FirstOrDefault(x => x.ToCharArray()
                    .Select(y => (int)y)
                    .Sum() >= number));
        }
    }
}
