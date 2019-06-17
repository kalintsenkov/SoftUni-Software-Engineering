using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003EnergyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string set = Console.ReadLine();
            int numberSets = int.Parse(Console.ReadLine());

            double price = 0;
            double priceSum = 0;
            double discount = 0;
            double totalPrice = 0;

            if(fruit == "Watermelon")
            {
                switch (set)
                {
                    case "small":
                        price = 2 * 56;
                        break;
                    case "big":
                        price = 5 * 28.70;
                        break;
                }
                priceSum = (double)price*numberSets;
                if(priceSum>= 400 && priceSum <= 1000)
                {
                    discount = priceSum * 0.15;
                }
                else if(priceSum > 1000)
                {
                    discount = priceSum * 0.5;
                }
                else
                {
                    Console.WriteLine($"{priceSum:F2} lv.");
                    return;
                }
                totalPrice = priceSum - discount;
            }
            else if(fruit == "Mango")
            {
                switch (set)
                {
                    case "small":
                        price = 2 * 36.66;
                        break;
                    case "big":
                        price = 5 * 19.60;
                        break;
                }
                priceSum = (double)price * numberSets;
                if (priceSum >= 400 && priceSum <= 1000)
                {
                    discount = priceSum * 0.15;
                }
                else if (priceSum > 1000)
                {
                    discount = priceSum * 0.5;
                }
                else
                {
                    Console.WriteLine($"{priceSum:F2} lv.");
                    return;
                }
                totalPrice = priceSum - discount;
            }
            else if(fruit == "Pineapple")
            {
                switch (set)
                {
                    case "small":
                        price = 2 * 42.10;
                        break;
                    case "big":
                        price = 5 * 24.80;
                        break;
                }
                priceSum = (double)price * numberSets;
                if (priceSum >= 400 && priceSum <= 1000)
                {
                    discount = priceSum * 0.15;
                }
                else if (priceSum > 1000)
                {
                    discount = priceSum * 0.5;
                }
                else
                {
                    Console.WriteLine($"{priceSum:F2} lv.");
                    return;
                }
                totalPrice = priceSum - discount;
            }
            else if(fruit == "Raspberry")
            {
                switch (set)
                {
                    case "small":
                        price = 2 * 20;
                        break;
                    case "big":
                        price = 5 * 15.20;
                        break;
                }
                priceSum = (double)price * numberSets;
                if (priceSum >= 400 && priceSum <= 1000)
                {
                    discount = priceSum * 0.15;
                }
                else if (priceSum > 1000)
                {
                    discount = priceSum * 0.5;
                }
                else
                {
                    Console.WriteLine($"{priceSum:F2} lv.");
                    return;
                }
                totalPrice = priceSum - discount;
            }
            Console.WriteLine($"{totalPrice:F2} lv.");
        }
    }
}
