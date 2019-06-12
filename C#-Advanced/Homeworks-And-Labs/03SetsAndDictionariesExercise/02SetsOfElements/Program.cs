using System;
using System.Collections.Generic;
using System.Linq;

namespace _02SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstNumber = numbers[0];
            int secondNumber = numbers[1];

            var firstSet = new HashSet<int>();

            for (int i = 0; i < firstNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            var secondSet = new HashSet<int>();

            for (int i = 0; i < secondNumber; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondSet.Add(number);
            }

            var resultSet = new HashSet<int>();

            foreach (var number1 in firstSet)
            {
                foreach (var number2 in secondSet)
                {
                    if (number1 == number2)
                    {
                        resultSet.Add(number1);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", resultSet));
        }
    }
}
