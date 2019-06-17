using System;
using System.Linq;

namespace _09Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new string[sizeOfMatrix, sizeOfMatrix]; // always a square

            var directions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int currentRow = 0;
            int currentCol = 0;
            int totalCoal = 0;

            MakeMatrixField(matrix, ref currentRow, ref currentCol, ref totalCoal);

            foreach (var direction in directions)
            {
                if (direction == "left")
                {
                    if (currentCol - 1 >= 0 && currentCol - 1 < matrix.GetLength(1))
                    {
                        currentCol--;
                    }
                }
                else if (direction == "right")
                {
                    if (currentCol + 1 >= 0 && currentCol + 1 < matrix.GetLength(1))
                    {
                        currentCol++;
                    }
                }
                else if (direction == "up")
                {
                    if (currentRow - 1 >= 0 && currentRow - 1 < matrix.GetLength(0))
                    {
                        currentRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (currentRow + 1 >= 0 && currentRow + 1 < matrix.GetLength(0))
                    {
                        currentRow++;
                    }
                }

                if (matrix[currentRow, currentCol] == "c")
                {
                    totalCoal--;
                    matrix[currentRow, currentCol] = "*";
                }
                else if (matrix[currentRow, currentCol] == "e")
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }

                if (totalCoal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    break;
                }
            }

            if (totalCoal > 0)
            {
                Console.WriteLine($"{totalCoal} coals left. ({currentRow}, {currentCol})");
            }
        }

        private static void MakeMatrixField(string[,] matrix, ref int currentRow, ref int currentCol, ref int totalCoal)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var fieldRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (fieldRow[col] == "*" ||
                        fieldRow[col] == "e")
                    {
                        matrix[row, col] = fieldRow[col];
                    }
                    else if (fieldRow[col] == "s")
                    {
                        matrix[row, col] = fieldRow[col];
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (fieldRow[col] == "c")
                    {
                        matrix[row, col] = fieldRow[col];
                        totalCoal++;
                    }
                }
            }

            matrix[currentRow, currentCol] = "*";
        }
    }
}
