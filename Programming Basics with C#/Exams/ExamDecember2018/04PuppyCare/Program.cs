using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PuppyCare
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int foodInGrams = food * 1000;

            int ateFood = 0;
            int foodSum = 0;

            while (input != "Adopted")
            {
                ateFood = int.Parse(input);
                foodSum = foodSum + ateFood;
                input = Console.ReadLine();
            }

            if (foodInGrams >= foodSum)
            {
               Console.WriteLine($"Food is enough! Leftovers: {foodInGrams-foodSum} grams.");
            }
            else
            {
               Console.WriteLine($"Food is not enough. You need {Math.Abs(foodInGrams-foodSum)} grams more.");
            }
            
        }
    }
}
