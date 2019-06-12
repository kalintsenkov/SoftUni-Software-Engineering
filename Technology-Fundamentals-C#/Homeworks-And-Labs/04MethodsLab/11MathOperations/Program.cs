using System;

namespace _11MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            decimal secondNumber = decimal.Parse(Console.ReadLine());

            decimal result = Result(firstNumber, @operator, secondNumber);
            Console.WriteLine(result);
        }

        static decimal Result(decimal firstNumber, string @operator, decimal secondNumber)
        {
            decimal result = 0m;

            if (@operator == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (@operator == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if(@operator == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if(@operator == "/")
            {
                result = firstNumber / secondNumber;
            }

            return result;
        }
    }
}
