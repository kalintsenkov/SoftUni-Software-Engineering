using System;
using System.Linq;

namespace P07EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int[] secondNumbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int sum = 0;

            for (int i = 0; i < firstNumbers.Length; i++)
            {
                if(firstNumbers[i] == secondNumbers[i])
                {
                    sum = sum + firstNumbers[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }

            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
