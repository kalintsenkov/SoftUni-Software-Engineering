using System;
using System.Linq;
using System.Collections.Generic;

namespace _05SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "register")
                {
                    string username = tokens[1];
                    string license = tokens[2];

                    if ((!dictionary.ContainsKey(username)) ||
                        (!dictionary.ContainsValue(license)))
                    {
                        dictionary.Add(username, license);
                        Console.WriteLine($"{username} registered {license} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {license}");
                    }
                }
                else if (command == "unregister")
                {
                    string username = tokens[1];

                    if (!dictionary.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        dictionary.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
