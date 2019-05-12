using System;
using System.Linq;
using System.Collections.Generic;

namespace _04Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            var productsDictionary = new Dictionary<string, double[]>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                if (!productsDictionary.ContainsKey(product))
                {
                    productsDictionary[product] = new double[2];

                    productsDictionary[product][0] = price;
                    productsDictionary[product][1] = quantity;
                }
                else
                {
                    productsDictionary[product][0] = price;
                    productsDictionary[product][1] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in productsDictionary)
            {
                double totalPrice = kvp.Value[0] * kvp.Value[1];
                Console.WriteLine($"{kvp.Key} -> {totalPrice:f2}");
            }
        }
    }
}
