using System;

namespace _07KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int removedKnights = 0;

            while (true)
            {
                int knightRow = int.MinValue;
                int knightCol = int.MinValue;
                int totalAttacks = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int tempAttacks = CountAttacks(matrix, row, col);

                            if (tempAttacks > totalAttacks)
                            {
                                totalAttacks = tempAttacks;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (totalAttacks > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedKnights);
        }

        private static int CountAttacks(char[,] matrix, int row, int col)
        {
            int attacks = 0;

            if (isValid(row - 2, col + 1, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row - 2, col - 1, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row - 1, col - 2, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row + 1, col - 2, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row + 2, col - 1, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row + 2, col + 1, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row - 1, col + 2, matrix))
            {                                    
                attacks++;                       
            }                                    
            if (isValid(row + 1, col + 2, matrix))
            {
                attacks++;
            }

            return attacks;
        }

        private static bool isValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1)
                && matrix[row, col] == 'K';
        }
    }
}
