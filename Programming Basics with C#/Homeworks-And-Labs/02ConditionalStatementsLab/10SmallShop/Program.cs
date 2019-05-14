using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string town = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            if (town == "Sofia")
            {
                if (product == "coffee")
                {
                    double price = 0.5 * amount;
                    Console.WriteLine(price);
                }
                else if(product == "water")
                {
                    double price = 0.8 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    double price = 1.20 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    double price = 1.45 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    double price = 1.60 * amount;
                    Console.WriteLine(price);
                }
            }
            else if(town == "Plovdiv")
            {
                if(product == "coffee")
                {
                    double price = 0.40 * amount;
                    Console.WriteLine(price);
                }
                else if(product == "water")
                {
                    double price = 0.70 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    double price = 1.15 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    double price = 1.30 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    double price = 1.50 * amount;
                    Console.WriteLine(price);
                }
            }
            else if(town == "Varna")
            {
                if (product == "coffee")
                {
                    double price = 0.45 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "water")
                {
                    double price = 0.70 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "beer")
                {
                    double price = 1.10 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "sweets")
                {
                    double price = 1.35 * amount;
                    Console.WriteLine(price);
                }
                else if (product == "peanuts")
                {
                    double price = 1.55 * amount;
                    Console.WriteLine(price);
                }
            }
            

        }
    }
}
