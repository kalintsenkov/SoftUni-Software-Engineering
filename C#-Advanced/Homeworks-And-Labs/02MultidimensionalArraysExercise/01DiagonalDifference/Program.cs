using System;
using System.Linq;

namespace _01DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = row;
                primaryDiagonalSum += matrix[row, col];
            }

            int secondaryDiagonalSum = 0;
            int currentCol = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                secondaryDiagonalSum += matrix[row, currentCol];
                currentCol++;
            }

            int difference = primaryDiagonalSum - secondaryDiagonalSum;

            Console.WriteLine(Math.Abs(difference));
        }
    }
}
