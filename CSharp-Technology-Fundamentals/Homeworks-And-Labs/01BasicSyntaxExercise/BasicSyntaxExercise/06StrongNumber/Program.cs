using System;

namespace _06StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int copyNumber = number;

            int currentNumber = 0;
            int factorial = 1;
            int factorialSum = 0;

            while (copyNumber != 0)
            {
                currentNumber = copyNumber % 10;
                copyNumber = copyNumber / 10;

                for(int i = 1; i <= currentNumber; i++)
                {
                    factorial = factorial * i;
                }
                factorialSum = factorialSum + factorial;
                factorial = 1;
            }
            if (number == factorialSum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
