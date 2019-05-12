using System;
using System.Linq;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var stores = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if(command == "Add")
                {
                    string storeName = tokens[1];

                    var items = tokens[2]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    if (!stores.ContainsKey(storeName))
                    {
                        stores.Add(storeName, new List<string>());
                    }

                    foreach (var item in items)
                    {
                        stores[storeName].Add(item);
                    }
                }
                else if(command == "Remove")
                {
                    string storeName = tokens[1];

                    if (stores.ContainsKey(storeName))
                    {
                        stores.Remove(storeName);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Stores list:");

            foreach (var store in stores
                .OrderByDescending(x => x.Value.Count())
                .ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{store.Key}");

                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
