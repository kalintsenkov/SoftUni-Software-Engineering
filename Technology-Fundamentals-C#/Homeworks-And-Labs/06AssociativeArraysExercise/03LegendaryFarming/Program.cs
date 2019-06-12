using System;
using System.Linq;
using System.Collections.Generic;

namespace _03LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyElements = new Dictionary<string, int>();

            keyElements["fragments"] = 0;
            keyElements["motes"] = 0;
            keyElements["shards"] = 0;

            var junkElements = new Dictionary<string, int>();

            bool haveWinner = false;

            while (haveWinner != true)
            {
                var tokens = Console.ReadLine()
                    .ToLower()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);

                    if (keyElements.ContainsKey(type))
                    {
                        keyElements[type] += quantity;

                        if (keyElements["motes"] >= 250)
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            keyElements["motes"] -= 250;
                            haveWinner = true;
                            break;
                        }
                        else if (keyElements["fragments"] >= 250)
                        {
                            Console.WriteLine("Valanyr obtained!");
                            keyElements["fragments"] -= 250;
                            haveWinner = true;
                            break;
                        }
                        else if (keyElements["shards"] >= 250)
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            keyElements["shards"] -= 250;
                            haveWinner = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkElements.ContainsKey(type))
                        {
                            junkElements[type] = quantity;
                        }
                        else
                        {
                            junkElements[type] += quantity;
                        }
                    }
                }

            }

            foreach (var kvp in keyElements
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junkElements.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
