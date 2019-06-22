using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ExcelFunctions
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            var matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            var commandArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command = commandArgs[0];
            string header = commandArgs[1];

            int indexOfHeader = Array.IndexOf(matrix[0], header);

            if (command == "hide")
            {
                for (int row = 0; row < rows; row++)
                {
                    var currentRow = new List<string>(matrix[row]);
                    currentRow.RemoveAt(indexOfHeader);
                    matrix[row] = currentRow.ToArray();

                    Console.WriteLine(string.Join(" | ", matrix[row]));
                }
            }
            else if (command == "sort")
            {
                var headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                matrix = matrix
                    .OrderBy(x => x[indexOfHeader])
                    .ToArray();

                foreach (var row in matrix)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if (command == "filter")
            {
                string value = commandArgs[2];
                var headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", headerRow));

                matrix = matrix
                    .Where(x => x[indexOfHeader] == value)
                    .ToArray();

                foreach (var row in matrix)
                {
                    Console.WriteLine(string.Join(" | ", row));
                }
            }
        }
    }
}
