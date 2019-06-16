using System;
using System.Linq;
using System.Text;

namespace _01TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int carrotsCount = 0;
            int potatoesCount = 0;
            int lettuceCount = 0;
            int harmedVegetablesCount = 0;

            var garden = new char[rows][];

            MakeGarden(rows, garden);

            string input = Console.ReadLine();

            while (input != "End of Harvest")
            {
                var commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commands[0];

                if (command == "Harvest")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);

                    if (IsInsideGarden(garden, row, col))
                    {
                        if (garden[row][col] == 'L')
                        {
                            lettuceCount++;
                        }
                        else if (garden[row][col] == 'P')
                        {
                            potatoesCount++;
                        }
                        else if (garden[row][col] == 'C')
                        {
                            carrotsCount++;
                        }

                        garden[row][col] = ' ';
                    }
                }
                else if (command == "Mole")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);

                    string direction = commands[3];

                    if (IsInsideGarden(garden, row, col))
                    {
                        if (garden[row][col] != ' ')
                        {
                            if (direction == "up")
                            {
                                harmedVegetablesCount = MoveUp(harmedVegetablesCount, garden, row, col);
                            }
                            else if (direction == "down")
                            {
                                harmedVegetablesCount = MoveDown(harmedVegetablesCount, garden, row, col);
                            }
                            else if (direction == "left")
                            {
                                harmedVegetablesCount = MoveLeft(harmedVegetablesCount, garden, row, col);
                            }
                            else if (direction == "right")
                            {
                                harmedVegetablesCount = MoveRight(harmedVegetablesCount, garden, row, col);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            PrintGarden(garden);

            string result = GetInfo(carrotsCount, potatoesCount, lettuceCount, harmedVegetablesCount);

            Console.WriteLine(result);
        }

        private static bool IsInsideGarden(char[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.Length
                && col >= 0 && col < garden[row].Length;
        }

        private static void MakeGarden(int rows, char[][] garden)
        {
            for (int row = 0; row < rows; row++)
            {
                var vegetables = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                garden[row] = new char[vegetables.Length];

                for (int col = 0; col < garden[row].Length; col++)
                {
                    garden[row][col] = vegetables[col];
                }
            }
        }

        private static int MoveRight(int harmedVegetablesCount, char[][] garden, int row, int col)
        {
            for (int currentCol = col; currentCol < garden[row].Length; currentCol += 2)
            {
                if (garden[row][currentCol] == 'L' || garden[row][currentCol] == 'C' || garden[row][currentCol] == 'P')
                {
                    harmedVegetablesCount++;
                    garden[row][currentCol] = ' ';
                }
            }

            return harmedVegetablesCount;
        }

        private static int MoveLeft(int harmedVegetablesCount, char[][] garden, int row, int col)
        {
            for (int currentCol = col; currentCol >= 0; currentCol -= 2)
            {
                if (garden[row][currentCol] == 'L' || garden[row][currentCol] == 'C' || garden[row][currentCol] == 'P')
                {
                    harmedVegetablesCount++;
                    garden[row][currentCol] = ' ';
                }
            }

            return harmedVegetablesCount;
        }

        private static int MoveDown(int harmedVegetablesCount, char[][] garden, int row, int col)
        {
            for (int currentRow = row; currentRow < garden.Length; currentRow += 2)
            {
                if (garden[currentRow][col] == 'C' || garden[currentRow][col] == 'P' || garden[currentRow][col] == 'L')
                {
                    harmedVegetablesCount++;
                    garden[currentRow][col] = ' ';
                }
            }

            return harmedVegetablesCount;
        }

        private static int MoveUp(int harmedVegetablesCount, char[][] garden, int row, int col)
        {
            for (int currentRow = row; currentRow >= 0; currentRow -= 2)
            {
                if (garden[currentRow][col] == 'C' || garden[currentRow][col] == 'P' || garden[currentRow][col] == 'L')
                {
                    harmedVegetablesCount++;
                    garden[currentRow][col] = ' ';
                }
            }

            return harmedVegetablesCount;
        }

        private static string GetInfo(int carrotsCount, int potatoesCount, int lettuceCount, int harmedVegetablesCount)
        {
            var result = new StringBuilder();

            result.AppendLine($"Carrots: {carrotsCount}");
            result.AppendLine($"Potatoes: {potatoesCount}");
            result.AppendLine($"Lettuce: {lettuceCount}");
            result.Append($"Harmed vegetables: {harmedVegetablesCount}");

            return result.ToString();
        }

        private static void PrintGarden(char[][] garden)
        {
            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
