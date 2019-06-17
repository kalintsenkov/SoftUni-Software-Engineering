using System;
using System.Linq;

namespace _08Bombs
{
    class Program
    {
        public static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfMatrix, sizeOfMatrix];

            MakeMatrix(matrix);

            var coordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var coordinate in coordinates)
            {
                var tokens = coordinate
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = tokens[0];
                int col = tokens[1];

                if (matrix[row, col] > 0)
                {
                    int value = matrix[row, col];
                    matrix[row, col] -= value;

                    if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) &&
                        col - 1 >= 0 && col - 1 < matrix.GetLength(1))
                    {
                        if (matrix[row - 1, col - 1] > 0)
                        {
                            matrix[row - 1, col - 1] -= value;
                        }
                    }
                    if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) &&
                        col >= 0 && col < matrix.GetLength(1))
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= value;
                        }
                    }
                    if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) &&
                        col + 1 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row - 1, col + 1] > 0)
                        {
                            matrix[row - 1, col + 1] -= value;
                        }
                    }
                    if (row >= 0 && row < matrix.GetLength(0) &&
                        col - 1 >= 0 && col - 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= value;
                        }
                    }
                    if (row >= 0 && row < matrix.GetLength(0) &&
                        col + 1 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= value;
                        }
                    }
                    if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) &&
                        col - 1 >= 0 && col - 1 < matrix.GetLength(1))
                    {
                        if (matrix[row + 1, col - 1] > 0)
                        {
                            matrix[row + 1, col - 1] -= value;
                        }
                    }
                    if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) &&
                        col >= 0 && col < matrix.GetLength(1))
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= value;
                        }
                    }
                    if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) &&
                        col + 1 >= 0 && col + 1 < matrix.GetLength(1))
                    {
                        if (matrix[row + 1, col + 1] > 0)
                        {
                            matrix[row + 1, col + 1] -= value;
                        }
                    }
                }
            }

            int sum = 0;
            int aliveCellsCount = 0;

            foreach (var element in matrix)
            {
                if (element > 0)
                {
                    sum += element;
                    aliveCellsCount++;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void MakeMatrix(int[,] matrix)
        {
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
        }
    }
}
