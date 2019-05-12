using System;
using System.Linq;
using System.Collections.Generic;

namespace _07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersAsStrings = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToList();

            List<int> numbers = new List<int>();

            foreach (var number in numbersAsStrings)
            {
                numbers.AddRange(number.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList()
                    );
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
