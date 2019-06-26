using System;
using System.Text;

namespace _02
{
    public class Program
    {
        public static int playerRow;
        public static int playerCol;
        public static int totalStarPower;

        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine()); 

            var galaxy = new char[matrixSize, matrixSize];

            InitializeGalaxy(matrixSize, galaxy);

            var isWon = false;

            while (true)
            {
                var direction = Console.ReadLine();

                galaxy[playerRow, playerCol] = '-';

                MovePlayer(direction);

                if (IsOutOfTheGalaxy(galaxy))
                {
                    break;
                }

                if (char.IsDigit(galaxy[playerRow, playerCol]))
                {
                    int starPower = int.Parse(galaxy[playerRow, playerCol].ToString());
                    totalStarPower += starPower;
                    galaxy[playerRow, playerCol] = '-';
                }
                else if (galaxy[playerRow, playerCol] == 'O')
                {
                    galaxy[playerRow, playerCol] = '-';

                    ChangePosition(galaxy);

                    galaxy[playerRow, playerCol] = 'S';
                }

                if (totalStarPower >= 50)
                {
                    galaxy[playerRow, playerCol] = 'S';
                    isWon = true;
                    break;
                }
            }

            var result = PrintOutput(galaxy, isWon);

            Console.WriteLine(result);
        }

        private static void InitializeGalaxy(int matrixSize, char[,] galaxy)
        {
            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrixSize; col++)
                {
                    galaxy[row, col] = currentRow[col];

                    if (galaxy[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                        galaxy[row, col] = '-';
                    }
                }
            }
        }
        
        private static void MovePlayer(string direction)
        {
            switch (direction)
            {
                case "up": playerRow--; break;
                case "down": playerRow++; break;
                case "left": playerCol--; break;
                case "right": playerCol++; break;
            }
        }
        
        private static bool IsOutOfTheGalaxy(char[,] galaxy)
        {
            return playerRow < 0 || playerRow >= galaxy.GetLength(0)
                || playerCol < 0 || playerCol >= galaxy.GetLength(1);
        }
        
        private static void ChangePosition(char[,] galaxy)
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    if (galaxy[row, col] == 'O')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
        
        private static string PrintOutput(char[,] galaxy, bool isWon)
        {
            var result = new StringBuilder();

            if (isWon)
            {
                result.AppendLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                result.AppendLine("Bad news, the spaceship went to the void.");
            }

            result.AppendLine($"Star power collected: {totalStarPower}");

            PrintMatrix(galaxy, result);

            return result.ToString().TrimEnd();
        }

        private static void PrintMatrix(char[,] galaxy, StringBuilder result)
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    result.Append($"{galaxy[row, col]}");
                }
                result.AppendLine();
            }
        }
    }
}
