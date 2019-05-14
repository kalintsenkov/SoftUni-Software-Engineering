using System;
using System.Linq;
using System.Collections.Generic;

namespace _01CookingMasterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal priceOfFlour = decimal.Parse(Console.ReadLine());
            decimal priceOfEgg = decimal.Parse(Console.ReadLine());
            decimal priceOfApron = decimal.Parse(Console.ReadLine());

            decimal totalEggsPrice = priceOfEgg * 10 * students;
            decimal totalApronPrice = priceOfApron * (students + Math.Ceiling(students * 0.20m));
            decimal freeFlour = students / 5;
            decimal totalFlourPrice = priceOfFlour * (students - freeFlour);
            
            decimal totalPrice = totalFlourPrice + totalEggsPrice + totalApronPrice;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Items purchased for {totalPrice:f2}$.");
            }
            else
            {
                Console.WriteLine($"{totalPrice-budget:f2}$ more needed.");
            }
        }
    }
}
