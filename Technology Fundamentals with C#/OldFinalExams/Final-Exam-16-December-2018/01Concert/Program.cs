using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var bandsTime = new Dictionary<string, int>();
            var bandsMembers = new Dictionary<string, List<string>>();

            while (input != "start of concert")
            {
                var tokens = input
                    .Split("; ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];
                string bandName = tokens[1];

                if (command == "Add")
                {
                    var membersList = tokens[2]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (!bandsMembers.ContainsKey(bandName))
                    {
                        bandsMembers.Add(bandName, new List<string>());
                    }

                    foreach (var member in membersList)
                    {
                        if (!bandsMembers.Any(x => x.Value.Contains(member)))
                        {
                            bandsMembers[bandName].Add(member);
                        }
                    }
                }
                else if (command == "Play")
                {
                    int time = int.Parse(tokens[2]);
                    
                    if (!bandsTime.ContainsKey(bandName))
                    {
                        bandsTime[bandName] = time;
                    }
                    else
                    {
                        bandsTime[bandName] += time;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total time: {bandsTime.Values.Sum()}");

            foreach (var band in bandsTime
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string wantedBand = Console.ReadLine();

            foreach (var kvp in bandsMembers.Where(x => x.Key == wantedBand))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var member in kvp.Value)
                {
                    Console.WriteLine($"=> {member}");
                }
            }
        }
    }
}
