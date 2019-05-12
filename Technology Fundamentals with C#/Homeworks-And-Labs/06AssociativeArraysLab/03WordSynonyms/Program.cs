using System;
using System.Linq;
using System.Collections.Generic;

namespace _03WordSynonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!dict.ContainsKey(word))
                {
                    dict[word] = new List<string>();
                }

                dict[word].Add(synonym);
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
