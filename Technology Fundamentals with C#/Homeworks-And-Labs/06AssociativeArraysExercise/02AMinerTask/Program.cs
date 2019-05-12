using System;
using System.Linq;
using System.Collections.Generic;

namespace _02AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!dictionary.ContainsKey(input))
                {
                    dictionary[input] = quantity;
                }
                else
                {
                    dictionary[input] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
