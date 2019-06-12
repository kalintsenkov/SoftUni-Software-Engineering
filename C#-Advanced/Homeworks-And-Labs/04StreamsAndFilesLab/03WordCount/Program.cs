using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "03. Word Count";
            string textPath = "text.txt";
            string wordsPath = "words.txt";

            string wordsFilePath = Path.Combine(folderPath, wordsPath);
            var textFilePath = Path.Combine(folderPath, textPath);

            var textLines = File.ReadAllLines(textFilePath);
            var words = File.ReadAllText(wordsFilePath)
                .Split()
                .ToArray();

            var wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount.Add(word, 0);
                }
            }

            foreach (var line in textLines)
            {
                var currentLine = line
                    .Split(new char[] { ' ', '.', ',', '!', '?', '-', '\'' });

                foreach (var currentWord in currentLine)
                {
                    string lowercaseWord = currentWord.ToLower();

                    if (wordsCount.ContainsKey(lowercaseWord))
                    {
                        wordsCount[lowercaseWord]++;
                    }
                }
            }

            string outputFilePath = "Output.txt";

            foreach (var (word, count) in wordsCount.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(outputFilePath, $"{word} - {count}{Environment.NewLine}");
            }
        }
    }
}
