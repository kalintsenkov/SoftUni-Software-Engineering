using System;
using System.Linq;
using System.Collections.Generic;

namespace _05WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ")
                .ToList();

            var result = words
                .Where(w => w.Length % 2 == 0)
                .ToList();

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
