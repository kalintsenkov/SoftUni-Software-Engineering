using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string mark = Console.ReadLine();

            double price = 0;
            double discount = 0;
            double discountSum = 0;

            if(typeOfRoom == "apartment")
            {
                days--;
                price = days * 25;

                if (days >= 1 && days < 10)
                {
                    discount = price - (price * 0.30);
                }
                else if (days >= 10 && days <= 15)
                {
                    discount = price - (price * 0.35);
                }
                else if (days > 15)
                {
                    discount = price - (price * 0.50);
                }

                if(mark == "positive")
                {
                    discountSum = discount + (discount * 0.25);
                }
                else if(mark == "negative")
                {
                    discountSum = discount - (discount * 0.10);
                }
            }
            else if(typeOfRoom == "president apartment")
            {
                days--;
                price = days * 35;

                if (days >= 1 && days < 10)
                {
                    discount = price - (price * 0.10);
                }
                else if (days >= 10 && days <= 15)
                {
                    discount = price - (price * 0.15);
                }
                else if (days > 15)
                {
                    discount = price - (price * 0.20);
                }

                if (mark == "positive")
                {
                    discountSum = discount + (discount * 0.25);
                }
                else if (mark == "negative")
                {
                    discountSum = discount - (discount * 0.10);
                }
            }
            else if (typeOfRoom == "room for one person")
            {
                days--;
                price = days * 18;

                if (days >= 1 && days < 10)
                {
                    discount = price;
                }
                else if (days >= 10 && days <= 15)
                {
                    discount = price;
                }
                else if (days > 15)
                {
                    discount = price;
                }

                if (mark == "positive")
                {
                    discountSum = discount + (discount * 0.25);
                }
                else if (mark == "negative")
                {
                    discountSum = discount - (discount * 0.10);
                }
            }
            Console.WriteLine($"{discountSum:F2}");
        }
    }
}
