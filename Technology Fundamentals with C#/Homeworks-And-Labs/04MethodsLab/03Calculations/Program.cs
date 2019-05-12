using System;

namespace _03Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string calculations = Console.ReadLine();
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            CalculationOfTwoNumbers(firstNumber, secondNumber, calculations);
        }

        static void CalculationOfTwoNumbers(
            double firstNumber,
            double secondNumber,
            string calculationType)
        {
            if (calculationType == "add")
            {
                Console.WriteLine(firstNumber + secondNumber);
            }
            else if (calculationType == "subtract")
            {
                Console.WriteLine(firstNumber - secondNumber);
            }
            else if (calculationType == "multiply")
            {
                Console.WriteLine(firstNumber * secondNumber);
            }
            else if (calculationType == "divide")
            {
                Console.WriteLine(firstNumber / secondNumber);
            }
        }
    }
}
