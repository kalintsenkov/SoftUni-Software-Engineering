using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = WhichIsSmallestNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(result);
        }

        static int WhichIsSmallestNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            int[] numbers = { firstNumber, secondNumber, thirdNumber };

            Array.Sort(numbers);

            return numbers[0];
        }
    }
}
