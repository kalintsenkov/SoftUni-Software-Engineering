using System;
using System.Linq;
using System.Collections.Generic;

namespace _02GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                var firstNumber = numbers[i];
                var lastNumber = numbers[numbers.Count - i - 1];

                var resultNumber = firstNumber + lastNumber;

                result.Add(resultNumber);
            }

            if (numbers.Count % 2 != 0)
            {
                result.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
