using System;
using System.Linq;
using System.Collections.Generic;

namespace _02PracticeSessions
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var dict = new Dictionary<string, List<string>>();

            while (input != "END")
            {
                var tokens = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Add")
                {
                    string road = tokens[1];
                    string racerName = tokens[2];

                    if (!dict.ContainsKey(road))
                    {
                        dict.Add(road, new List<string>());
                    }

                    dict[road].Add(racerName);
                }
                else if (command == "Move")
                {
                    string currentRoad = tokens[1];
                    string racerName = tokens[2];
                    string nextRoad = tokens[3];

                    if (dict.ContainsKey(currentRoad))
                    {
                        if (dict[currentRoad].Any(x => x.Contains(racerName)))
                        {
                            dict[currentRoad].Remove(racerName);

                            if (dict.ContainsKey(nextRoad))
                            {
                                dict[nextRoad].Add(racerName);
                            }
                        }
                    }
                }
                else if (command == "Close")
                {
                    string road = tokens[1];

                    if (dict.ContainsKey(road))
                    {
                        dict.Remove(road);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");

            foreach (var kvp in dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var racer in kvp.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
