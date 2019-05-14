using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02FootballKit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tShirtPrice = double.Parse(Console.ReadLine());
            double moneyToWin = double.Parse(Console.ReadLine());

            double shortsPrice = tShirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.2;
            double footballShoes = (shortsPrice + tShirtPrice) * 2;
            double totalSum = tShirtPrice + shortsPrice + socksPrice + footballShoes;
            double discount = totalSum - (totalSum * 0.15);

            if (discount >= moneyToWin)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {discount:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {(moneyToWin-discount):F2} lv. more.");
            }
        }
    }
}
