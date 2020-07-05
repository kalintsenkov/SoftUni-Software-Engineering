using System;
using System.Linq;

namespace P06EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rightSum = 0;
            int leftSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum += numbers[i];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum -= numbers[i];
                
                if(rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                else
                {
                    leftSum += numbers[i];
                }
            }

            Console.WriteLine("no");
        }
    }
}
