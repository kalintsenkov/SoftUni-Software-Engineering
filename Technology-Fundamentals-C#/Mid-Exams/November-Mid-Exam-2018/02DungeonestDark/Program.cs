using System;
using System.Collections.Generic;
using System.Linq;

namespace _02DungeonestDark
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int initalHealth = 100;
            int initalCoins = 0;

            var items = new List<string>();
            var values = new List<int>();

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] currentRoom = rooms[i].Split();
                items.Add(currentRoom[0]);
                values.Add(int.Parse(currentRoom[1]));
            }

            int roomCounter = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                roomCounter++;

                if (items[i] == "potion")
                {
                    initalHealth = HealingPotion(initalHealth, values, i);
                }
                else if (items[i] == "chest")
                {
                    initalCoins = FoundingCoins(initalCoins, values, i);
                }
                else
                {
                    string monster = items[i];
                    int attackDamage = values[i];

                    if (attackDamage < initalHealth)
                    {
                        initalHealth = initalHealth - attackDamage;
                        Console.WriteLine($"You slayed {monster}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {roomCounter}");
                        return;
                    }
                }
            }

            PrintingResult(initalHealth, initalCoins);
        }

        private static int HealingPotion(int initalHealth, List<int> values, int i)
        {
            int healing = values[i];

            if (initalHealth + healing < 100)
            {
                initalHealth = initalHealth + healing;
                Console.WriteLine($"You healed for {healing} hp.");
            }
            else
            {
                Console.WriteLine($"You healed for {100 - initalHealth} hp.");
                initalHealth = 100;
            }

            Console.WriteLine($"Current health: {initalHealth} hp.");
            return initalHealth;
        }

        private static int FoundingCoins(int initalCoins, List<int> values, int i)
        {
            int coins = values[i];
            Console.WriteLine($"You found {coins} coins.");
            initalCoins = initalCoins + coins;
            return initalCoins;
        }

        private static void PrintingResult(int initalHealth, int initalCoins)
        {
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Coins: {initalCoins}");
            Console.WriteLine($"Health: {initalHealth}");
        }
    }
}
