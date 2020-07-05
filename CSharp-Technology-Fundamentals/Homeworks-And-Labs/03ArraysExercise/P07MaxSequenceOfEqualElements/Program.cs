using System;
using System.Linq;

namespace P07MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int maxCounter = 1;
            int number = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    if (counter > maxCounter)
                    {
                        maxCounter = counter;
                        number = numbers[i];
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            int[] longestSequence = new int[maxCounter];

            for (int i = 0; i < longestSequence.Length; i++)
            {
                longestSequence[i] = number;
            }
            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}
