using System;
using System.Linq;
using System.Collections.Generic;

namespace _02BreadFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] events = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int initialEnergy = 100;
            int initalCoins = 100;

            var stuff = new List<string>();
            var numbers = new List<int>();

            for (int i = 0; i < events.Length; i++)
            {
                string[] tokens = events[i]
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                stuff.Add(tokens[0]);
                numbers.Add(int.Parse(tokens[1]));
            }

            for (int i = 0; i < events.Length; i++)
            {
                if (stuff[i] == "rest")
                {
                    int energy = numbers[i];

                    if (initialEnergy + energy < 100)
                    {
                        initialEnergy = initialEnergy + energy;
                        Console.WriteLine($"You gained {energy} energy.");
                    }
                    else
                    {
                        Console.WriteLine($"You gained {100 - initialEnergy} energy.");
                        initialEnergy = 100;
                    }

                    Console.WriteLine($"Current energy: {initialEnergy}.");
                }
                else if (stuff[i] == "order")
                {
                    int coins = numbers[i];

                    initialEnergy = initialEnergy - 30;

                    if (initialEnergy >= 0)
                    {
                        initalCoins = initalCoins + coins;
                        Console.WriteLine($"You earned {coins} coins.");
                    }
                    else
                    {
                        initialEnergy = initialEnergy + 30; //skipping order
                        initialEnergy = initialEnergy + 50;
                        Console.WriteLine("You had to rest!");
                    }
                }
                else
                {
                    string ingredient = stuff[i];
                    int price = numbers[i];

                    if (initalCoins - price > 0)
                    {
                        initalCoins = initalCoins - price;
                        Console.WriteLine($"You bought {ingredient}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {ingredient}.");
                        return;
                    }
                }
            }

            Console.WriteLine("Day completed!");
            Console.WriteLine($"Coins: {initalCoins}");
            Console.WriteLine($"Energy: {initialEnergy}");
        }
    }
}
