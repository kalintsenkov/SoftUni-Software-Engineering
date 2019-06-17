using System;
using System.IO;
using System.Linq;

namespace _02LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";
            string outputPath = "output.txt";

            var textLines = File.ReadAllLines(textPath);

            int lineCounter = 1;

            foreach (var line in textLines)
            {
                int lettersCount = line.Count(char.IsLetter);
                int punctuationCount = line.Count(char.IsPunctuation);

                File.AppendAllText(outputPath, $"Line {lineCounter}: {line} ({lettersCount})({punctuationCount}){Environment.NewLine}");

                lineCounter++;
            }
        }
    }
}
