using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Dictionary
{
    class Program
    {
        public static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<string>>();
            var wordsList = new List<string>();

            var wordsAndDefinitions = Console.ReadLine()
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            foreach (var item in wordsAndDefinitions)
            {
                var tokens = item
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string word = tokens[0];
                string definition = tokens[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                    wordsList.Add(word);
                }

                dictionary[word].Add(definition);
            }

            var wordTokens = Console.ReadLine()
                .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var word in wordTokens)
            {
                if (dictionary.ContainsKey(word))
                {
                    foreach (var kvp in dictionary.Where(x => x.Key == word))
                    {
                        Console.WriteLine($"{kvp.Key}");
                        foreach (var definition in kvp.Value.OrderByDescending(x => x.Length))
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }
            }

            string commmand = Console.ReadLine();

            if (commmand == "End")
            {
                return;
            }
            else if (commmand == "List")
            {
                Console.WriteLine(string.Join(" ", wordsList.OrderBy(x => x)));
            }
        }
    }
}
