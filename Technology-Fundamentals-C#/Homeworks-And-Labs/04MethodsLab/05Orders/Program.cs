using System;

namespace _05Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculatingTotalPrice(order, quantity);
        }

        static void CalculatingTotalPrice(string product, int quantityOfTheProduct)
        {
            if (product == "coffee")
            {
                Console.WriteLine($"{1.5 * quantityOfTheProduct:f2}");
            }
            else if (product == "water")
            {
                Console.WriteLine($"{1.00 * quantityOfTheProduct:f2}");
            }
            else if (product == "coke")
            {
                Console.WriteLine($"{1.40 * quantityOfTheProduct:f2}");
            }
            else if (product == "snacks")
            {
                Console.WriteLine($"{2.00 * quantityOfTheProduct:f2}");
            }
        }
    }
}
