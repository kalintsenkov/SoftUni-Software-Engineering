using System;

namespace _08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            long factorialOfFirstNumber = CalculatingFactorialOfNumber(firstNumber);
            long factorialOfSecondNumber = CalculatingFactorialOfNumber(secondNumber);

            double finalResult = (double)factorialOfFirstNumber / factorialOfSecondNumber;
            Console.WriteLine($"{finalResult:f2}");
        }

        private static long CalculatingFactorialOfNumber(long number)
        {
            long factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial = factorial * i;
            }

            return factorial;
        }
    }
}
