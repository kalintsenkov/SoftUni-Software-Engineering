using System;

namespace _10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            int trashedHeadsetCount = 0;
            int trashedMouseCount = 0;
            int trashedKeyboardCount = 0;
            int trashedDisplayCount = 0;

            for (int game = 1; game <= lostGames; game++)
            {
                if (game % 2 == 0)
                {
                    trashedHeadsetCount++;
                }
                if (game % 3 == 0)
                {
                    trashedMouseCount++;
                }
                if (game % 2 == 0 && game % 3 == 0)
                {
                    trashedKeyboardCount++;
                    if (trashedKeyboardCount % 2 == 0)
                    {
                        trashedDisplayCount++;
                    }
                }
            }

            decimal totalExpenses = headsetPrice * trashedHeadsetCount + mousePrice * trashedMouseCount + keyboardPrice * trashedKeyboardCount
                + displayPrice * trashedDisplayCount;

            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
