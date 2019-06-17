using System;
using System.Collections.Generic;
using System.Linq;

namespace _08Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var dict = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                var tokens = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = tokens[0];
                string password = tokens[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                var tokens = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contests.ContainsKey(contest) &&
                    contests[contest] == password)
                {
                    if (!dict.ContainsKey(username))
                    {
                        dict.Add(username, new Dictionary<string, int>());
                    }

                    if (!dict[username].ContainsKey(contest))
                    {
                        dict[username][contest] = points;
                    }

                    if (dict[username][contest] < points)
                    {
                        dict[username][contest] = points;
                    }
                }

                input = Console.ReadLine();
            }

            var candidatesPoints = new Dictionary<string, int>();

            foreach (var kvp in dict)
            {
                if (!candidatesPoints.ContainsKey(kvp.Key))
                {
                    candidatesPoints.Add(kvp.Key, kvp.Value.Values.Sum());
                }
            }

            int bestPoints = candidatesPoints.Values.Max();

            foreach (var kvp in candidatesPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {bestPoints} points.");
                }
            }

            Console.WriteLine("Ranking:");
            foreach (var kvp in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);

                foreach (var contest in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
