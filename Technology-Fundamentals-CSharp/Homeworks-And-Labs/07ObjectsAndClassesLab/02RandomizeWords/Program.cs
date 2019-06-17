using System;
using System.Linq;

namespace _02RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var rnd = new Random();

            for (int i = 0; i < words.Count - 1; i++)
            {
                int randomNumber = rnd.Next(0, words.Count);

                string temp = words[i];
                words[i] = words[randomNumber];
                words[randomNumber] = temp;
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
