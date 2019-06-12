using System;

namespace _01ChristmasSpirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            decimal budget = 0m;
            int spirit = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity = quantity + 2;
                }
                if (i % 2 == 0)
                {
                    budget = budget + (2 * quantity);
                    spirit = spirit + 5;
                }
                if (i % 3 == 0)
                {
                    budget = budget + (5 * quantity) + (3 * quantity);
                    spirit = spirit + 13;
                }
                if (i % 5 == 0)
                {
                    budget = budget + 15 * quantity;
                    spirit = spirit + 17;
                    if (i % 3 == 0)
                    {
                        spirit = spirit + 30;
                    }
                }
                if (i % 10 == 0)
                {
                    spirit = spirit - 20;
                    budget = budget + 5 + 3 + 15;
                }
                if (i % 10 == 0 && i == days)
                {
                    spirit = spirit - 30;
                }
            }
            Console.WriteLine($"Total cost: {budget}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
