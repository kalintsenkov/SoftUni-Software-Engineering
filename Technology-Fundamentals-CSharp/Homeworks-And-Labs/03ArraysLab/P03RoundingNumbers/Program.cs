using System;
using System.Linq;

namespace P03RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().
                Split().
                Select(double.Parse).
                ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNumber = numbers[i];
                numbers[i] = Math.Round(numbers[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{currentNumber} => {numbers[i]}");
            }
        }
    }
}
