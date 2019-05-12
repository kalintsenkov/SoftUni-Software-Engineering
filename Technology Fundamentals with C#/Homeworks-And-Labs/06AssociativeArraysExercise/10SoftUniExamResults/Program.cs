using System;
using System.Linq;
using System.Collections.Generic;

namespace _10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var results = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            while (input != "exam finished")
            {
                var tokens = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string username = tokens[0];
                string command = tokens[1];

                if (command == "banned")
                {
                    if (results.ContainsKey(username))
                    {
                        results.Remove(username); // {username}-banned
                    }
                }
                else
                {
                    string language = command;
                    int points = int.Parse(tokens[2]);

                    if (!results.ContainsKey(username))
                    {
                        results[username] = points;
                    }
                    else
                    {
                        if (results[username] <= points)
                        {
                            results[username] = points;
                        }
                    }

                    if (!submissions.ContainsKey(command))
                    {
                        submissions[command] = 1;
                    }
                    else
                    {
                        submissions[command]++;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");

            foreach (var kvp in results
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in submissions
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
