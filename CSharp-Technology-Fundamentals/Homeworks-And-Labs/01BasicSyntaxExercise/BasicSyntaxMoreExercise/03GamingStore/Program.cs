using System;

namespace _03GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal currentBalance = decimal.Parse(Console.ReadLine());

            decimal price = 0m;
            decimal totalPrice = 0m;

            string input = Console.ReadLine();

            while (input != "Game Time")
            {
                if (input == "OutFall 4")
                {
                    price = 39.99m;
                }
                else if (input == "CS: OG")
                {
                    price = 15.99m;
                }
                else if (input == "Zplinter Zell")
                {
                    price = 19.99m;
                }
                else if (input == "Honored 2")
                {
                    price = 59.99m;
                }
                else if (input == "RoverWatch")
                {
                    price = 29.99m;
                }
                else if (input == "RoverWatch Origins Edition")
                {
                    price = 39.99m;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    input = Console.ReadLine();
                    continue;
                }

                if (price <= currentBalance)
                {
                    Console.WriteLine($"Bought {input}");
                    totalPrice = totalPrice + price;
                    currentBalance = currentBalance - price;
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${totalPrice:F2}. Remaining: ${currentBalance:f2}");
        }
    }
}