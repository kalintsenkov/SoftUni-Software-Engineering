using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int numberFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double flowerPrice = 0;

            switch (flower)
            {
                case "Roses":
                    flowerPrice = 5;
                    break;
                case "Dahlias":
                    flowerPrice = 3.80;
                    break;
                case "Tulips":
                    flowerPrice = 2.80;
                    break;
                case "Narcissus":
                    flowerPrice = 3;
                    break;
                case "Gladiolus":
                    flowerPrice = 2.50;
                    break;
            }

            double totalPrice = flowerPrice * numberFlowers;

            if (flower == "Tulips")
            {
                if (numberFlowers > 80)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
            }
            else if (flower == "Roses")
            {
                if(numberFlowers > 80)
                {
                    totalPrice = totalPrice - (totalPrice * 0.10);
                }
            }
            else if(flower == "Dahlias")
            {
                if (numberFlowers > 90)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
            }
            else if(flower == "Narcissus")
            {
                if (numberFlowers < 120)
                {
                    totalPrice = totalPrice + (totalPrice * 0.15);
                }
            }
            else if(flower == "Gladiolus")
            {
                if (numberFlowers < 80)
                {
                    totalPrice = totalPrice + (totalPrice * 0.20);
                }
            }

            if (totalPrice > budget)
            {
                Console.WriteLine($"Not enough money, you need {(totalPrice-budget):f2} leva more.");
            }
            else
            {
                Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {flower} and {(budget-totalPrice):f2} leva left.");
            }
        }
    }
}
