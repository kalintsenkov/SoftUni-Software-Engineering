using System;
using System.Text;

namespace _07NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            MakingMatrix(number);
        }

        private static void MakingMatrix(int number)
        {
            for (int row = 1; row <= number; row++)
            {
                for (int col = 1; col <= number; col++)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
