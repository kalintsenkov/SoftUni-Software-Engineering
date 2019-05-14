using System;
using System.Linq;
using System.Collections.Generic;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            var collectionOfItems = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            double budget = double.Parse(Console.ReadLine());

            double originalBudget = budget;

            var items = new List<string>();
            var currentPrices = new List<double>();

            for (int i = 0; i < collectionOfItems.Count; i++)
            {
                string[] tokens = collectionOfItems[i]
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                items.Add(tokens[0]);
                currentPrices.Add(double.Parse(tokens[1]));
            }

            var newPrices = new List<double>();

            for (int i = 0; i < collectionOfItems.Count; i++)
            {
                if(items[i] == "Clothes")
                {
                    double price = currentPrices[i];

                    if (price <= 50)
                    {
                        if (budget - price >= 0)
                        {
                            budget -= price;
                            double money = price + (price * 0.40);
                            newPrices.Add(money);
                        }
                    }
                }
                else if(items[i] == "Shoes")
                {
                    double price = currentPrices[i];

                    if(price <= 35)
                    {
                        if (budget - price >= 0)
                        {
                            budget -= price;
                            double money = price + (price * 0.40);
                            newPrices.Add(money);
                        }
                    }
                }
                else if(items[i] == "Accessories")
                {
                    double price = currentPrices[i];

                    if (price <= 20.50)
                    {
                        if (budget - price >= 0)
                        {
                            budget -= price;
                            double money = price + (price * 0.40);
                            newPrices.Add(money);
                        }
                    }
                }
            }

            double sumOfAllNewPrices = 0;

            foreach (double price in newPrices)
            {
                sumOfAllNewPrices += price;
            }

            sumOfAllNewPrices += budget;

            double profit = sumOfAllNewPrices - originalBudget;

            if (sumOfAllNewPrices >= 150)
            {
                for (int i = 0; i < newPrices.Count; i++)
                {
                    Console.Write($"{newPrices[i]:f2} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Profit: {profit:f2}");
                Console.WriteLine("Hello, France!");
            }
            else
            {
                for (int i = 0; i < newPrices.Count; i++)
                {
                    Console.Write($"{newPrices[i]:f2} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Profit: {profit:f2}");
                Console.WriteLine("Time to go.");
            }
            
        }
    }
}
