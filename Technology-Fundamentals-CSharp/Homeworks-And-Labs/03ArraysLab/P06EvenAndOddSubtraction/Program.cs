using System;
using System.Linq;

namespace P06EvenAndOddSubtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int sumOfEvenNumbers = 0;
            int sumOfOddNumbers = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 == 0)
                {
                    sumOfEvenNumbers = sumOfEvenNumbers + numbers[i];
                }
                else
                {
                    sumOfOddNumbers = sumOfOddNumbers + numbers[i];
                }
            }
            Console.WriteLine(sumOfEvenNumbers-sumOfOddNumbers);
        }
    }
}
