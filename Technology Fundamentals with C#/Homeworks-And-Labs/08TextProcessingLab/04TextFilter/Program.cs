using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var bannedWords = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string text = Console.ReadLine();

            foreach (var word in bannedWords)
            {
                if (text.Contains(word))
                {
                    string asterisks = new string('*', word.Length);
                    text = text.Replace(word, asterisks);
                }
            }

            Console.WriteLine(text);
        }
    }
}
