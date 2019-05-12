using System;

namespace _04PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintingTriangle(number);
            PrintingReversedTriangle(number - 1);
        }

        static void PrintingTriangle(int maxNumber)
        {
            for (int row = 1; row <= maxNumber; row++)
            {
                PrintingNumbers(row);
            }
        }

        static void PrintingReversedTriangle(int maxNumber)
        {
            for (int row = maxNumber; row >= 1; row--)
            {
                PrintingNumbers(row);
            }
        }

        static void PrintingNumbers(int row)
        {
            for (int j = 1; j <= row; j++)
            {
                Console.Write($"{j} ");
            }
            Console.WriteLine();
        }
    }
}
