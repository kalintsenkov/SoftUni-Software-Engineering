using System;
using System.IO;
using System.Linq;

namespace _01EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "text.txt";

            int counter = 0;

            using (var reader = new StreamReader(filePath))
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    if (counter % 2 == 0)
                    {
                        string replacedLine = ReplaceSymbols(currentLine);

                        var reversedLine = replacedLine
                            .Split()
                            .Reverse()
                            .ToArray();

                        Console.WriteLine(string.Join(" ", reversedLine));
                    }

                    counter++;

                    currentLine = reader.ReadLine();
                }
            }
        }

        private static string ReplaceSymbols(string currentLine)
        {
            return currentLine
                        .Replace("-", "@")
                        .Replace(",", "@")
                        .Replace(".", "@")
                        .Replace("!", "@")
                        .Replace("?", "@");
        }
    }
}
