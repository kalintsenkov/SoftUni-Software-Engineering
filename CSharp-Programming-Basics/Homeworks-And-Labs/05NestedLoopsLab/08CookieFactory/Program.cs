using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08CookieFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool hasFlour = false;
            bool hasEggs = false;
            bool hasSugar = false;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                while (input != "Bake!")
                {
                    if(input == "flour")
                    {
                        hasFlour = true;
                    }
                    else if(input == "eggs")
                    {
                        hasEggs = true;
                    }
                    else if(input == "sugar")
                    {
                        hasSugar = true;
                    }
                    input = Console.ReadLine();
                }

                if (hasEggs && hasSugar && hasFlour)
                {
                    Console.WriteLine($"Baking batch number {i}...");
                    hasEggs = false;
                    hasSugar = false;
                    hasFlour = false;
                }
                else
                {
                    Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    i--;
                }
            }
        }
    }
}
