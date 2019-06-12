using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[1];

                if (command == "joined")
                {
                    string vloggerName = tokens[0];

                    if (!dict.ContainsKey(vloggerName))
                    {
                        dict.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        dict[vloggerName].Add("followers", new HashSet<string>());
                        dict[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string firstVlogger = tokens[0];
                    string secondVlogger = tokens[2];

                    if (dict.ContainsKey(firstVlogger) &&
                        dict.ContainsKey(secondVlogger) &&
                        firstVlogger != secondVlogger)
                    {
                        dict[secondVlogger]["followers"].Add(firstVlogger);
                        dict[firstVlogger]["following"].Add(secondVlogger);
                    }
                }

                input = Console.ReadLine();
            }

            int number = 1;

            Console.WriteLine($"The V-Logger has a total of {dict.Keys.Count} vloggers in its logs.");

            foreach (var kvp in dict.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");

                if (number == 1)
                {
                    foreach (var follower in kvp.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                number++;
            }
        }
    }
}
