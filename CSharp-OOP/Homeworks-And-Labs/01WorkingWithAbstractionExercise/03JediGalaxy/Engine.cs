namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Engine
    {
        private int[,] matrix;
        private long sum;

        public void Run()
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            InitializeMatrix(rows, cols);

            var command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                var playerCoordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilCoordinates = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evilRow = evilCoordinates[0];
                var evilCol = evilCoordinates[1];

                MoveEvil(evilRow, evilCol);

                var playerRow = playerCoordinates[0];
                var playerCol = playerCoordinates[1];

                MovePlayer(playerRow, playerCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        private void MoveEvil(int row, int col)
        {
            while (row >= 0 && col >= 0)
            {
                if (IsInsideMatrix(row, col))
                {
                    matrix[row, col] = 0;
                }

                row--;
                col--;
            }
        }

        private void MovePlayer(int row, int col)
        {
            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (IsInsideMatrix(row, col))
                {
                    sum += matrix[row, col];
                }

                col++;
                row--;
            }
        }

        private void InitializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            var value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        private bool IsInsideMatrix(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
