using System;
using System.Linq;

namespace _04MatrixShuffling
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

            var matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "swap")
                {
                    if (tokens.Length - 1 == 4)
                    {
                        int firstRow = int.Parse(tokens[1]);
                        int firstCol = int.Parse(tokens[2]);
                        int secondRow = int.Parse(tokens[3]);
                        int secondCol = int.Parse(tokens[4]);

                        if (firstRow >= 0 && firstRow < matrix.GetLength(0) &&
                            secondRow >= 0 && secondRow < matrix.GetLength(0) &&
                            firstCol >= 0 && firstCol < matrix.GetLength(1) &&
                            secondCol >= 0 && secondCol < matrix.GetLength(1))
                        {
                            string temp = matrix[firstRow, firstCol];
                            matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                            matrix[secondRow, secondCol] = temp;

                            PrintMatrix(matrix);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
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
    }
}
