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
            string sweet = Console.ReadLine();
            int numberSweets = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());

            double price = 0;
            double priceAfterDiscount = 0;
            double totalPrice = 0;
            double discount = 0;
            double discountForDay = 0;

            if(sweet == "Cake")
            {
                if (day <= 15)
                {
                    price = (double)numberSweets * 24;
                    if (price >= 100 && price <= 200)
                    {
                        discount = price * 0.15;
                        priceAfterDiscount = price - discount;
                        discountForDay = priceAfterDiscount * 0.10;
                        totalPrice = priceAfterDiscount - discountForDay;
                    }
                    else if (price > 200)
                    {
                        discount = price * 0.25;
                        priceAfterDiscount = price - discount;
                        discountForDay = priceAfterDiscount * 0.10;
                        totalPrice = priceAfterDiscount - discountForDay;
                    }
                }
                else if (day > 15 && day <= 22)
                {
                    price = (double)numberSweets * 28.70;
                    if (price >= 100 && price <= 200)
                    {
                        discount = price * 0.15;
                        priceAfterDiscount = price - discount;
                        totalPrice = priceAfterDiscount;
                    }
                    else if (price > 200)
                    {
                        discount = price * 0.25;
                        priceAfterDiscount = price - discount;
                        totalPrice = priceAfterDiscount;
                    }
                }
                if (day > 22)
                {
                    totalPrice = (double)numberSweets * 28.70;
                }
            }
            else if(sweet == "Souffle")
            {
                if (day <= 15)
                {
                    price = (double)numberSweets * 6.66;
                    if (price >= 100 && price <= 200)
                    {
                        discount = price * 0.15;
                        priceAfterDiscount = price - discount;
                        discountForDay = priceAfterDiscount * 0.10;
                        totalPrice = priceAfterDiscount - discountForDay;
                    }
                    else if (price > 200)
                    {
                        discount = price * 0.25;
                        priceAfterDiscount = price - discount;
                        discountForDay = priceAfterDiscount * 0.10;
                        totalPrice = priceAfterDiscount - discountForDay;
                    }
                }
                else if (day > 15 && day <= 22)
                {
                    price = (double)numberSweets * 9.80;
                    if (price >= 100 && price <= 200)
                    {
                        discount = price * 0.15;
                        priceAfterDiscount = price - discount;
                        totalPrice = priceAfterDiscount;
                    }
                    else if (price > 200)
                    {
                        discount = price * 0.25;
                        priceAfterDiscount = price - discount;
                        totalPrice = priceAfterDiscount;
                    }
                }
                if (day > 22)
                {
                    totalPrice = (double)numberSweets * 9.80;
                }
            }
            else if(sweet == "Baklava")
            {
                if (day <= 15)
                {
                    price = (double)numberSweets * 12.60;
                    if (price >= 100 && price <= 200)
                    {
                        discount = price * 0.15;
                        priceAfterDiscount = price - discount;
                        discountForDay = priceAfterDiscount * 0.10;
                        totalPrice = priceAfterDiscount - discountForDay;
                    }
                    else if (price > 200)
                    {
                        discount = price * 0.25;
                        priceAfterDiscount = price - discount;
                        discountForDay = priceAfterDiscount * 0.10;
                        totalPrice = priceAfterDiscount - discountForDay;
                    }
                }
                else if (day > 15 && day <= 22)
                {
                    price = (double)numberSweets * 16.98;
                    if (price >= 100 && price <= 200)
                    {
                        discount = price * 0.15;
                        priceAfterDiscount = price - discount;
                        totalPrice = priceAfterDiscount;
                    }
                    else if (price > 200)
                    {
                        discount = price * 0.25;
                        priceAfterDiscount = price - discount;
                        totalPrice = priceAfterDiscount;
                    }
                }
                if (day > 22)
                {
                    totalPrice = (double)numberSweets * 16.98;
                }
            }
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
