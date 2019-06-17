using System;
using System.Linq;

namespace _03MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = int.MinValue;
            int indexOfRow = int.MinValue;
            int indexOfCol = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        indexOfRow = row;
                        indexOfCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[indexOfRow, indexOfCol]} {matrix[indexOfRow, indexOfCol + 1]} {matrix[indexOfRow, indexOfCol + 2]}");
            Console.WriteLine($"{matrix[indexOfRow + 1, indexOfCol]} {matrix[indexOfRow + 1, indexOfCol + 1]} {matrix[indexOfRow + 1, indexOfCol + 2]}");
            Console.WriteLine($"{matrix[indexOfRow + 2, indexOfCol]} {matrix[indexOfRow + 2, indexOfCol + 1]} {matrix[indexOfRow + 2, indexOfCol + 2]}");
        }
    }
}
