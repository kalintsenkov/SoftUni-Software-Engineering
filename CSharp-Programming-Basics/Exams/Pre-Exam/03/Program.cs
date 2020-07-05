using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfSushi = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            int numberPortions = int.Parse(Console.ReadLine());
            char order = char.Parse(Console.ReadLine());

            double money = 0;
            double totalMoney = 0;
            double discount = 0;

            if(typeOfSushi == "maki")
            {
                switch (restaurantName)
                {
                    case "Sushi Zone":
                        money = 5.29 * numberPortions;
                        break;
                    case "Sushi Time":
                        money = 4.69 * numberPortions;
                        break;
                    case "Sushi Bar":
                        money = 5.55 * numberPortions;
                        break;
                    case "Asian Pub":
                        money = 4.80 * numberPortions;
                        break;
                    default:
                        Console.WriteLine($"{restaurantName} is invalid restaurant!");
                        return;
                }

                if (order == 'Y')
                {
                    discount = money * 0.20;
                    totalMoney = Math.Ceiling(money + discount);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
                else if(order == 'N')
                {
                    totalMoney = Math.Ceiling(money);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
            }
            else if(typeOfSushi == "sashimi")
            {
                switch (restaurantName)
                {
                    case "Sushi Zone":
                        money = 4.99 * numberPortions;
                        break;
                    case "Sushi Time":
                        money = 5.49 * numberPortions;
                        break;
                    case "Sushi Bar":
                        money = 5.25 * numberPortions;
                        break;
                    case "Asian Pub":
                        money = 4.50 * numberPortions;
                        break;
                    default:
                        Console.WriteLine($"{restaurantName} is invalid restaurant!");
                        return;
                }

                if (order == 'Y')
                {
                    discount = money * 0.20;
                    totalMoney = Math.Ceiling(money + discount);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
                else if (order == 'N')
                {
                    totalMoney = Math.Ceiling(money);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
            }
            else if(typeOfSushi == "uramaki")
            {
                switch (restaurantName)
                {
                    case "Sushi Zone":
                        money = 5.99 * numberPortions;
                        break;
                    case "Sushi Time":
                        money = 4.49 * numberPortions;
                        break;
                    case "Sushi Bar":
                        money = 6.25 * numberPortions;
                        break;
                    case "Asian Pub":
                        money = 5.50 * numberPortions;
                        break;
                    default:
                        Console.WriteLine($"{restaurantName} is invalid restaurant!");
                        return;
                }

                if (order == 'Y')
                {
                    discount = money * 0.20;
                    totalMoney = Math.Ceiling(money + discount);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
                else if (order == 'N')
                {
                    totalMoney = Math.Ceiling(money);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
            }
            else if(typeOfSushi == "temaki")
            {
                switch (restaurantName)
                {
                    case "Sushi Zone":
                        money = 4.29 * numberPortions;
                        break;
                    case "Sushi Time":
                        money = 5.19 * numberPortions;
                        break;
                    case "Sushi Bar":
                        money = 4.75 * numberPortions;
                        break;
                    case "Asian Pub":
                        money = 5.50 * numberPortions;
                        break;
                    default:
                        Console.WriteLine($"{restaurantName} is invalid restaurant!");
                        return;
                }

                if (order == 'Y')
                {
                    discount = money * 0.20;
                    totalMoney = Math.Ceiling(money + discount);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
                else if (order == 'N')
                {
                    totalMoney = Math.Ceiling(money);
                    Console.WriteLine($"Total price: {totalMoney} lv.");
                }
            }
        }
    }
}
