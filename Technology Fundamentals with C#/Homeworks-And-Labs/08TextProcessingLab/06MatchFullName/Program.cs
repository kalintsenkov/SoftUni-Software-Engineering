using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _06MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            var matchedNames = Regex.Matches(names, @"\b[A-Z][a-z]+ [A-Z][a-z]+\b");

            foreach (Match name in matchedNames)
            {
                Console.Write($"{name} ");
            }
        }
    }
}
