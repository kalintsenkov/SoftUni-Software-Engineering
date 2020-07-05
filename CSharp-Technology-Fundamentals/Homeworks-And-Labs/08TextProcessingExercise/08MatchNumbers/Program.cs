using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var numbers = new List<string>();

            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            var validNumbers = Regex.Matches(input, pattern);

            foreach (Match match in validNumbers)
            {
                numbers.Add(match.ToString());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
