using System;
using System.Linq;
using System.Collections.Generic;

namespace _02NascarQualifications
{
    class Program
    {
        static void Main(string[] args)
        {
            var racersList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Race")
                {
                    string racer = tokens[1];

                    if (!racersList.Contains(racer))
                    {
                        racersList.Add(racer);
                    }
                }
                else if (command == "Accident")
                {
                    string racer = tokens[1];

                    if (racersList.Contains(racer))
                    {
                        racersList.Remove(racer);
                    }
                }
                else if (command == "Box")
                {
                    string racer = tokens[1];
                    int indexOfRacer = racersList.IndexOf(racer);

                    if (racersList.Contains(racer) && indexOfRacer < racersList.Count)
                    {
                        racersList.Remove(racer);
                        racersList.Insert(indexOfRacer + 1, racer);
                    }
                }
                else if (command == "Overtake")
                {
                    string racer = tokens[1];
                    int racersCount = int.Parse(tokens[2]);

                    int indexOfRacer = racersList.IndexOf(racer);
                    int indexOfFirstRacer = racersList.IndexOf(racersList[0]);

                    if (racersList.Contains(racer))
                    {
                        if (indexOfRacer - racersCount >= indexOfFirstRacer)
                        {
                            racersList.Remove(racer);
                            racersList.Insert(indexOfRacer - racersCount, racer);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ~ ", racersList));
        }
    }
}
