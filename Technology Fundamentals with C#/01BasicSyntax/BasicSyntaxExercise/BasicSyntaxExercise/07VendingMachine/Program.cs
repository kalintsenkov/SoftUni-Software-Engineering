using System;

namespace _07VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            decimal coins = 0;
            decimal money = 0;
            decimal totalMoney = 0;

            while (command != "Start")
            {
                coins = decimal.Parse(command);
                if (coins == 0.1m)
                {
                    money = 0.1m;
                }
                else if (coins == 0.2m)
                {
                    money = 0.2m;
                }
                else if (coins == 0.5m)
                {
                    money = 0.5m;
                }
                else if (coins == 1m)
                {
                    money = 1m;
                }
                else if (coins == 2m)
                {
                    money = 2m;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    money = 0m;
                }
                totalMoney = totalMoney + money;
                command = Console.ReadLine();
            }

            string input = Console.ReadLine();

            decimal price = 0m;
            decimal totalPrice = 0m;

            while (input != "End")
            {
                if (input == "Nuts")
                {
                    price = 2.0m;
                }
                else if (input == "Water")
                {
                    price = 0.7m;
                }
                else if (input == "Crisps")
                {
                    price = 1.5m;
                }
                else if (input == "Soda")
                {
                    price = 0.8m;
                }
                else if (input == "Coke")
                {
                    price = 1.0m;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }
                
                if (price <= totalMoney && price > 0)
                {
                    Console.WriteLine($"Purchased {input.ToLower()}");
                    totalMoney = totalMoney - price;
                }
                else if (price > totalMoney && price > 0)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}
