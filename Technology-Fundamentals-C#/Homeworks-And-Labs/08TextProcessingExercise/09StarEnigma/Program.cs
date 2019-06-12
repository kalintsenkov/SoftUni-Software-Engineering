using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _09StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());

            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();

            string pattern = @"@(?<planet>[A-Z][a-z]+)(?:[^@:!\->]*)\:(?<population>[0-9]+)\!(?<attack>[AD])\!(?:[^@:!\->]*)\-\>(?<count>[0-9]+)";

            for (int i = 1; i <= numberOfMessages; i++)
            {
                string message = Console.ReadLine();

                StringBuilder sb = new StringBuilder();

                int lettersCount = 0;

                for (int letter = 0; letter < message.Length; letter++)
                {
                    if (message[letter] == 's' || message[letter] == 't' || message[letter] == 'a' || message[letter] == 'r' ||
                        message[letter] == 'S' || message[letter] == 'T' || message[letter] == 'A' || message[letter] == 'R')
                    {
                        lettersCount++;
                    }
                }

                for (int j = 0; j < message.Length; j++)
                {
                    char decryptedSymbol = (char)(message[j] - lettersCount);

                    sb.Append(decryptedSymbol);
                }

                string decryptedMessage = sb.ToString();

                var validLines = Regex.Matches(decryptedMessage, pattern);

                foreach (Match match in validLines)
                {
                    string position = match.Groups["attack"].Value;
                    string planetName = match.Groups["planet"].Value;

                    if (position.Contains("A"))
                    {
                        if (!attackedPlanets.Contains(planetName))
                        {
                            attackedPlanets.Add(planetName);
                        }
                    }
                    else if (position.Contains("D"))
                    {
                        if (!destroyedPlanets.Contains(planetName))
                        {
                            destroyedPlanets.Add(planetName);
                        }
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            attackedPlanets.Sort();

            foreach (var planet in attackedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            destroyedPlanets.Sort();

            foreach (var planet in destroyedPlanets)
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
