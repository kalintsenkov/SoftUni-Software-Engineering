using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002WeddingParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int covertPrice = guests * 20;

            if (covertPrice <= budget)
            {
                int moneyLeft = budget - covertPrice;
                double fireworksPrice = moneyLeft * 0.4;
                double moneyForCharity = moneyLeft - fireworksPrice;

                Console.WriteLine($"Yes! {fireworksPrice:F0} lv are for fireworks and {moneyForCharity:F0} lv are for donation.");
            }
            else
            {
                int moneyNeeded = covertPrice - budget;

                Console.WriteLine($"They won't have enough money to pay the covert. They will need {moneyNeeded:F0} lv more.");
            }
        }
    }
}
