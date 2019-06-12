using System;
using System.Collections.Generic;
using System.Linq;

namespace _03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minNumberFunc = numbers =>
            {
                int minNumber = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(minNumberFunc(inputNumbers));
        }
    }
}
