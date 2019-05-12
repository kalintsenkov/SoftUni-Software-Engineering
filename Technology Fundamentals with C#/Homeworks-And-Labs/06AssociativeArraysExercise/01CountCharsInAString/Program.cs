using System;
using System.Linq;
using System.Collections.Generic;

namespace _01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> characters = Console.ReadLine()
                .Where(x => x != ' ')
                .ToList();

            var dictionary = new Dictionary<char, int>();

            foreach (var character in characters)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary[character] = 1;
                }
                else
                {
                    dictionary[character]++;
                }
            }

            foreach (var character in dictionary)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
