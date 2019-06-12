using System;
using System.Collections.Generic;
using System.Linq;

namespace _10PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];
                string criteria = tokens[1];

                if (command == "Double")
                {
                    Func<string, bool> filterFunc = GetFilter(criteria, tokens[2]);
                    var filteredNames = names.Where(filterFunc).ToList();

                    names.InsertRange(0, filteredNames);
                }
                else if (command == "Remove")
                {
                    Predicate<string> predicate = GetPredicate(criteria, tokens[2]);

                    names.RemoveAll(predicate);
                }

                input = Console.ReadLine();
            }

            if (names.Any())
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string criteria, string filter)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(filter);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(filter);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(filter);
            }
            else
            {
                return x => true;
            }
        }

        private static Func<string, bool> GetFilter(string criteria, string filter)
        {
            if (criteria == "StartsWith")
            {
                return x => x.StartsWith(filter);
            }
            else if (criteria == "EndsWith")
            {
                return x => x.EndsWith(filter);
            }
            else if (criteria == "Length")
            {
                return x => x.Length == int.Parse(filter);
            }
            else
            {
                return x => true;
            }
        }
    }
}
