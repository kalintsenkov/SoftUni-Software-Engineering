using System;
using System.Linq;
using System.Collections.Generic;

namespace _05BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bomb = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bomb[0];
            int bombPower = bomb[1];
            
            BombNumbers(numbers, bombNumber, bombPower);
            
            Console.WriteLine(numbers.Sum());
        }

        private static void BombNumbers(List<int> numbers, int bombNumber, int bombPower)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    for (int j = 0; j < bombPower; j++)
                    {
                        int leftIndex = i - 1;

                        if (leftIndex == 0)
                        {
                            numbers.RemoveAt(leftIndex);
                            i = i - 1;
                            break;
                        }
                        else if (leftIndex < 0)
                        {
                            break;
                        }
                        else if (leftIndex > 0)
                        {
                            numbers.RemoveAt(leftIndex);
                            i = i - 1;
                        }
                    }

                    for (int j = 0; j < bombPower; j++)
                    {
                        int rightIndex = i + 1;

                        if (rightIndex == numbers.Count - 1)
                        {
                            numbers.RemoveAt(rightIndex);
                            break;
                        }
                        else if (rightIndex > numbers.Count - 1)
                        {
                            break;
                        }
                        else if (rightIndex < numbers.Count - 1)
                        {
                            numbers.RemoveAt(rightIndex);
                        }
                    }

                    numbers.Remove(bombNumber);
                    i = -1;
                }
            }
        }
    }
}
