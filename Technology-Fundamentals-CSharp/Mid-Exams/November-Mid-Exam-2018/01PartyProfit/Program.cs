using System;

namespace _01PartyProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            decimal coins = 0m;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                if (currentDay % 10 == 0)
                {
                    partySize = partySize - 2;
                }
                if (currentDay % 15 == 0)
                {
                    partySize = partySize + 5;
                }
                if (currentDay % 1 == 0)
                {
                    coins += 50;
                    coins = coins - 2 * partySize;
                }
                if (currentDay % 3 == 0)
                {
                    coins = coins - 3 * partySize;
                }
                if (currentDay % 5 == 0)
                {
                    coins = coins + 20 * partySize;
                    if (currentDay % 3 == 0)
                    {
                        coins = coins - 2 * partySize;
                    }
                }
            }

            Console.WriteLine($"{partySize} companions received {Math.Floor(coins / partySize)} coins each.");
        }
    }
}
