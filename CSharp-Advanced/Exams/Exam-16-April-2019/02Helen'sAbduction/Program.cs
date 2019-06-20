using System;

namespace _02Helen_sAbduction
{
    public class Program
    {
        public static void Main()
        {
            int parisEnergy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            var matrix = new char[rows][];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                matrix[row] = new char[currentRow.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row][col] = '-';
                    }
                }
            }

            bool isWon = false;

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                string direction = commands[0];
                int enemyRow = int.Parse(commands[1]);
                int enemyCol = int.Parse(commands[2]);

                matrix[enemyRow][enemyCol] = 'S';
                parisEnergy--;

                if (direction == "up")
                {
                    if (IsInside(matrix, playerRow - 1, playerCol))
                    {
                        playerRow--;
                    }
                }
                else if (direction == "down")
                {
                    if (IsInside(matrix, playerRow + 1, playerCol))
                    {
                        playerRow++;
                    }
                }
                else if (direction == "left")
                {
                    if (IsInside(matrix, playerRow, playerCol - 1))
                    {
                        playerCol--;
                    }
                }
                else if (direction == "right")
                {
                    if (IsInside(matrix, playerRow, playerCol + 1))
                    {
                        playerCol++;
                    }
                }

                if (matrix[playerRow][playerCol] == 'S')
                {
                    parisEnergy -= 2;
                }
                else if (matrix[playerRow][playerCol] == 'H')
                {
                    matrix[playerRow][playerCol] = '-';
                    isWon = true;
                    break;
                }

                if (parisEnergy > 0)
                {
                    matrix[playerRow][playerCol] = '-';
                }
                else
                {
                    matrix[playerRow][playerCol] = 'X';
                    break;
                }
            }

            if (isWon)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {playerRow};{playerCol}.");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool IsInside(char[][] matrix, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < matrix.Length
                && playerCol >= 0 && playerCol < matrix[playerRow].Length;
        }
    }
}
