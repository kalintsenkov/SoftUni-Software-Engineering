using System;
using System.Linq;

namespace P03ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstNumbers = new int[n];
            int[] secondNumbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().
                    Split().
                    Select(int.Parse).
                    ToArray();

                if(i % 2 == 0)
                {
                    firstNumbers[i] = numbers[0];
                    secondNumbers[i] = numbers[1];
                }
                else
                {
                    firstNumbers[i] = numbers[1];
                    secondNumbers[i] = numbers[0];
                }
            }
            Console.WriteLine(string.Join(" ",firstNumbers));
            Console.WriteLine(string.Join(" ",secondNumbers));
        }
    }
}
