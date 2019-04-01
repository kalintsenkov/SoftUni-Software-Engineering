using System;

namespace _07TheatrePromotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfday = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            decimal price = 0m;

            if (typeOfday == "Weekday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 12m;
                    Console.WriteLine($"{price}$");
                }
                else if(age > 18 && age <= 64)
                {
                    price = 18m;
                    Console.WriteLine($"{price}$");
                }
                else if(age > 64 && age <= 122)
                {
                    price = 12m;
                    Console.WriteLine($"{price}$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (typeOfday == "Weekend")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 15m;
                    Console.WriteLine($"{price}$");
                }
                else if (age > 18 && age <= 64)
                {
                    price = 20m;
                    Console.WriteLine($"{price}$");
                }
                else if (age > 64 && age <= 122)
                {
                    price = 15m;
                    Console.WriteLine($"{price}$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            else if (typeOfday == "Holiday")
            {
                if (age >= 0 && age <= 18)
                {
                    price = 5m;
                    Console.WriteLine($"{price}$");
                }
                else if (age > 18 && age <= 64)
                {
                    price = 12m;
                    Console.WriteLine($"{price}$");
                }
                else if (age > 64 && age <= 122)
                {
                    price = 10m;
                    Console.WriteLine($"{price}$");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }
    }
}
