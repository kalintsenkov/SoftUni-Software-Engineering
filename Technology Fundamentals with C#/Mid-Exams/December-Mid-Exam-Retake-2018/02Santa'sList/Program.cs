using System;
using System.Linq;
using System.Collections.Generic;

namespace _02Santa_sList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kidsList = Console.ReadLine()
                .Split("&", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Finished!")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                string operation = commands[0];

                MakingOperations(kidsList, commands, operation);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", kidsList));
        }

        private static void MakingOperations(List<string> kidsList, string[] commands, string operation)
        {
            if (operation == "Bad")
            {
                string kidName = commands[1];

                if (!kidsList.Contains(kidName))
                {
                    kidsList.Insert(0, kidName);
                }
            }
            else if (operation == "Good")
            {
                string kidName = commands[1];

                if (kidsList.Contains(kidName))
                {
                    kidsList.Remove(kidName);
                }
            }
            else if (operation == "Rename")
            {
                string kidName = commands[1];
                string newName = commands[2];

                if (kidsList.Contains(kidName))
                {
                    int indexOfKid = kidsList.IndexOf(kidName);
                    kidsList[indexOfKid] = newName;
                }
            }
            else if (operation == "Rearrange")
            {
                string kidName = commands[1];

                if (kidsList.Contains(kidName))
                {
                    kidsList.Remove(kidName);
                    kidsList.Add(kidName);
                }
            }
        }
    }
}
