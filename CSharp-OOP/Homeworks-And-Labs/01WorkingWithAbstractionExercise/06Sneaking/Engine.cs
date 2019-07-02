namespace P06_Sneaking
{
    using System;

    public class Engine
    {
        private char[][] matrix;

        private int nikoladzeRow;
        private int nikoladzeCol;

        private int playerRow;
        private int playerCol;

        public void Run()
        {
            var rows = int.Parse(Console.ReadLine());

            InitializeMatrix(rows);

            var moves = Console.ReadLine();

            var isWin = false;

            foreach (var move in moves)
            {
                MoveEnemies();

                if (IsWatched(matrix))
                {
                    matrix[playerRow][playerCol] = 'X';
                    break;
                }

                MovePlayer(move);

                if (matrix[playerRow][playerCol] == 'b' || matrix[playerRow][playerCol] == 'd')
                {
                    matrix[playerRow][playerCol] = '.';
                }
                else if (playerRow == nikoladzeRow)
                {
                    isWin = true;
                    matrix[nikoladzeRow][nikoladzeCol] = 'X';
                    matrix[playerRow][playerCol] = 'S';
                    break;
                }
            }

            PrintOutput(isWin);
        }

        private void PrintOutput(bool isWin)
        {
            if (isWin)
            {
                Console.WriteLine("Nikoladze killed!");
            }
            else
            {
                Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
            }

            PrintMatrix(matrix);
        }

        private bool IsWatched(char[][] matrix)
        {
            var isWatched = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b' && row == playerRow)
                    {
                        if (playerCol > col)
                        {
                            isWatched = true;
                            break;
                        }
                    }
                    else if (matrix[row][col] == 'd' && row == playerRow)
                    {
                        if (playerCol < col)
                        {
                            isWatched = true;
                            break;
                        }
                    }
                }

                if (isWatched)
                {
                    break;
                }
            }

            return isWatched;
        }

        private void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private void MovePlayer(char move)
        {
            switch (move)
            {
                case 'U': playerRow--; break;
                case 'D': playerRow++; break;
                case 'L': playerCol--; break;
                case 'R': playerCol++; break;
            }
        }

        private void MoveEnemies()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        matrix[row][col] = '.';

                        if (col + 1 >= 0 && col + 1 < matrix[row].Length)
                        {
                            matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        matrix[row][col] = '.';

                        if (col - 1 >= 0 && col - 1 < matrix[row].Length)
                        {
                            matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private void InitializeMatrix(int rows)
        {
            matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                        matrix[row][col] = '.';
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        nikoladzeRow = row;
                        nikoladzeCol = col;
                    }
                }
            }
        }
    }
}
