using System;

namespace _02TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int firstPlayerRow = -1;
            int firstPlayerCol = -1;
            int secondPlayerRow = -1;
            int secondPlayerCol = -1;

            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();

                matrix[row] = new char[currentRow.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (matrix[row][col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            while (true)
            {
                var directions = Console.ReadLine().Split();

                string firstPlayerDirections = directions[0];
                string secondPlayerDirections = directions[1];

                switch (firstPlayerDirections)
                {
                    case "up": firstPlayerRow--; break;
                    case "down": firstPlayerRow++; break;
                    case "left": firstPlayerCol--; break;
                    case "right": firstPlayerCol++; break;
                }

                switch (secondPlayerDirections)
                {
                    case "up": secondPlayerRow--; break;
                    case "down": secondPlayerRow++; break;
                    case "left": secondPlayerCol--; break;
                    case "right": secondPlayerCol++; break;
                }

                if (IsOutside(firstPlayerRow, firstPlayerCol, matrix))
                {
                    firstPlayerRow = ChangePlayerRow(firstPlayerRow, matrix);
                    firstPlayerCol = ChangePlayerCol(firstPlayerRow, firstPlayerCol, matrix);
                }

                if (IsOutside(secondPlayerRow, secondPlayerCol, matrix))
                {
                    secondPlayerRow = ChangePlayerRow(secondPlayerRow, matrix);
                    secondPlayerCol = ChangePlayerCol(secondPlayerRow, secondPlayerCol, matrix);
                }

                if (matrix[firstPlayerRow][firstPlayerCol] == '*')
                {
                    matrix[firstPlayerRow][firstPlayerCol] = 'f';
                }
                else if (matrix[firstPlayerRow][firstPlayerCol] == 's')
                {
                    matrix[firstPlayerRow][firstPlayerCol] = 'x';
                    break;
                }

                if (matrix[secondPlayerRow][secondPlayerCol] == '*')
                {
                    matrix[secondPlayerRow][secondPlayerCol] = 's';
                }
                else if (matrix[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    matrix[secondPlayerRow][secondPlayerCol] = 'x';
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        private static int ChangePlayerRow(int row, char[][] matrix)
        {
            if (row < 0)
            {
                row = matrix.Length - 1;
            }
            else if (row >= matrix.Length)
            {
                row = 0;
            }

            return row;
        }

        private static int ChangePlayerCol(int row, int col, char[][] matrix)
        {
            if (col < 0)
            {
                col = matrix[row].Length - 1;
            }
            else if (col >= matrix[row].Length)
            {
                col = 0;
            }

            return col;
        }

        private static bool IsOutside(int row, int col, char[][] matrix)
        {
            return row < 0 || row >= matrix.Length
                || col < 0 || col >= matrix[row].Length;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
