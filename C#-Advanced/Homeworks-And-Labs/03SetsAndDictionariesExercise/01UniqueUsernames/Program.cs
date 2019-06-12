using System;
using System.Collections.Generic;

namespace _01UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
