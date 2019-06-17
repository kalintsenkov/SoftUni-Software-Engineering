using System;
using System.Collections.Generic;
using System.Linq;

namespace _05SnakeMoves
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

            var matirx = new char[rows, cols];

            string input = Console.ReadLine();

            var snake = new Queue<char>(input);

            for (int row = 0; row < matirx.GetLength(0); row++)
            {
                for (int col = 0; col < matirx.GetLength(1); col++)
                {
                    var currentSymbol = snake.Dequeue();
                    matirx[row, col] = currentSymbol;
                    snake.Enqueue(currentSymbol);
                }
            }

            PrintMatrix(matirx);
        }

        private static void PrintMatrix(char[,] matirx)
        {
            for (int row = 0; row < matirx.GetLength(0); row++)
            {
                for (int col = 0; col < matirx.GetLength(1); col++)
                {
                    Console.Write(matirx[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
