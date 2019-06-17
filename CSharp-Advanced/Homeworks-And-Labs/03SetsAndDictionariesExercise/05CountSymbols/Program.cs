using System;
using System.Collections.Generic;
using System.Linq;

namespace _05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var charactersCount = new Dictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var character in input)
            {
                if (!charactersCount.ContainsKey(character))
                {
                    charactersCount[character] = 1;
                }
                else
                {
                    charactersCount[character]++;
                }
            }

            foreach (var kvp in charactersCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
