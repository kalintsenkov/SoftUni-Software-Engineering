using System;
using System.Collections.Generic;
using System.Linq;

namespace _11ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> removedNames = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                var tokens = input
                    .Split(";", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];

                if (command == "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(filterType, filterParameter);

                    removedNames.AddRange(names.Where(x => predicate(x)));
                    names.RemoveAll(predicate);
                }
                else if (command == "Remove filter")
                {
                    Func<string, bool> filterFunc = GetFilter(filterType, filterParameter);

                    names.AddRange(removedNames.Where(filterFunc));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", names));
        }

        private static Func<string, bool> GetFilter(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                return x => x.StartsWith(filterParameter);
            }
            else if (filterType == "Ends with")
            {
                return x => x.EndsWith(filterParameter);
            }
            else if (filterType == "Length")
            {
                return x => x.Length == int.Parse(filterParameter);
            }
            else if (filterType == "Contains")
            {
                return x => x.Contains(filterParameter);
            }
            else
            {
                return x => true;
            }
        }

        private static Predicate<string> GetPredicate(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                return x => x.StartsWith(filterParameter);
            }
            else if (filterType == "Ends with")
            {
                return x => x.EndsWith(filterParameter);
            }
            else if (filterType == "Length")
            {
                return x => x.Length == int.Parse(filterParameter);
            }
            else if (filterType == "Contains")
            {
                return x => x.Contains(filterParameter);
            }
            else
            {
                return x => true;
            }
        }
    }
}
