using System;

namespace _05AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = SumOfFirstAndSecondNumber(firstNumber, secondNumber);
            int subtract = SubtractThirdNumberFromSum(thirdNumber, sum);

            Console.WriteLine(subtract);
        }

        private static int SubtractThirdNumberFromSum(int thirdNumber, int sum)
        {
            int result = sum - thirdNumber;
            return result;
        }

        private static int SumOfFirstAndSecondNumber(int firstNumber, int secondNumber)
        {
            int result = firstNumber + secondNumber;
            return result;
        }
    }
}
