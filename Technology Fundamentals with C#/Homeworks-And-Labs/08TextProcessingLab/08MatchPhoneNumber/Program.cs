using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string numbers = Console.ReadLine();

            var matchNumbers = Regex.Matches(numbers, @"([+359]{4})([ -])([2])\2(([0-9]{3})\2([0-9]{4}))\b");

            var listOfNumbers = new List<string>();

            foreach (Match number in matchNumbers)
            {
                listOfNumbers.Add(number.Value);
            }

            Console.WriteLine(string.Join(", ", listOfNumbers));
        }
    }
}
