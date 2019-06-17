using System;
using System.Collections.Generic;
using System.Linq;

namespace _04InternationalSoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            var competition = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string countryName = tokens[0];
                string contestantName = tokens[1];
                int contestantPoints = int.Parse(tokens[2]);

                if (!competition.ContainsKey(countryName))
                {
                    competition.Add(countryName, new Dictionary<string, int>());
                }

                if (!competition[countryName].Any(x => x.Key == contestantName))
                {
                    competition[countryName].Add(contestantName, contestantPoints);
                }
                else
                {
                    competition[countryName][contestantName] += contestantPoints;
                }

                input = Console.ReadLine();
            }

            foreach (var country in competition.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"{country.Key}: {country.Value.Values.Sum()}");

                foreach (var contestant in country.Value)
                {
                    Console.WriteLine($" -- {contestant.Key} -> {contestant.Value}");
                }
            }
        }
    }
}
