using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07SummerOutfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            if(degrees <= 10 || degrees <= 18)
            {
                if(time == "Morning")
                {
                    string Outfit = "Sweatshirt";
                    string Shoes = "Sneakers";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
                else if(time == "Afternoon")
                {
                    string Outfit = "Shirt";
                    string Shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
                else if(time == "Evening")
                {
                    string Outfit = "Shirt";
                    string Shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
            }
            else if(degrees < 18 || degrees <= 24)
            {
                if (time == "Morning")
                {
                    string Outfit = "Shirt";
                    string Shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
                else if (time == "Afternoon")
                {
                    string Outfit = "T-Shirt";
                    string Shoes = "Sandals";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
                else if (time == "Evening")
                {
                    string Outfit = "Shirt";
                    string Shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
            }
            else if (degrees >= 25)
            {
                if (time == "Morning")
                {
                    string Outfit = "T-Shirt";
                    string Shoes = "Sandals";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
                else if (time == "Afternoon")
                {
                    string Outfit = "Swim Suit";
                    string Shoes = "Barefoot";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
                else if (time == "Evening")
                {
                    string Outfit = "Shirt";
                    string Shoes = "Moccasins";
                    Console.WriteLine($"It's {degrees} degrees, get your {Outfit} and {Shoes}.");
                }
            }
        }
    }
}
