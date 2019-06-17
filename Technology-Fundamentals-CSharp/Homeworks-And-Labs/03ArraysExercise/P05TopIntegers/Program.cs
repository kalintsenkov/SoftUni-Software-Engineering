using System;
using System.Linq;

namespace P05TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        break;
                    }
                    else if (j == numbers.Length - 1)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
            }
            Console.WriteLine(numbers[numbers.Length - 1]);
        }
    }
}
