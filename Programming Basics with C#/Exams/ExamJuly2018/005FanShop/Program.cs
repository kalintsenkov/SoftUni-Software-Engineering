using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005FanShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int articlePrice = 0;
            int totalPrice = 0;

            for (int i = 1; i <= n; i++)
            {
                string article = Console.ReadLine();

                if(article == "hoodie")
                {
                    articlePrice = 30;
                }
                else if(article == "keychain")
                {
                    articlePrice = 4;
                }
                else if (article == "T-shirt")
                {
                    articlePrice = 20;
                }
                else if (article == "flag")
                {
                    articlePrice = 15;
                }
                else if (article == "sticker")
                {
                    articlePrice = 1;
                }

                totalPrice = totalPrice + articlePrice;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"You bought {n} items and left with {budget-totalPrice} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice-budget} more lv.");
            }
        }
    }
}
