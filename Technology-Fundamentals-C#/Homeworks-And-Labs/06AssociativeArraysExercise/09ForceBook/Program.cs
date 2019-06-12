using System;
using System.Linq;
using System.Collections.Generic;

namespace _09ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    var tokens = input.Split(" | ").ToArray();
                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    if (!dict.ContainsKey(forceSide))
                    {
                        dict.Add(forceSide, new List<string>());
                    }

                    if (!dict.Any(x => x.Value.Contains(forceUser)))
                    {
                        dict[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains("->"))
                {
                    var tokens = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string forceUser = tokens[0];
                    string forceSide = tokens[1];

                    if (dict.Any(x => x.Value.Contains(forceUser)))
                    {
                        foreach (var kvp in dict)
                        {
                            if (kvp.Value.Contains(forceUser))
                            {
                                kvp.Value.Remove(forceUser);
                            }
                        }
                    }

                    if (!dict.ContainsKey(forceSide))
                    {
                        dict.Add(forceSide, new List<string>());
                    }

                    if (!dict.Any(x => x.Value.Contains(forceUser)))
                    {
                        dict[forceSide].Add(forceUser);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in dict
                .Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                foreach (var user in kvp.Value
                    .OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
