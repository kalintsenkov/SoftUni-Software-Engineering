using System;
using System.Linq;
using System.Collections.Generic;

namespace _01SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main()
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if(numbers[i] == numbers[i + 1])
                {
                    numbers[i] = numbers[i] + numbers[i+1];
                    numbers.Remove(numbers[i+1]);

                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
