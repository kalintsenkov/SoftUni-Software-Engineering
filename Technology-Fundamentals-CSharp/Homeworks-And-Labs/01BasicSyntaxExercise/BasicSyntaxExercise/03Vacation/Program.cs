using System;

namespace _03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupOfPeople = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();

            decimal price = 0m;
            decimal totalPrice = 0m;

            if(dayOfWeek == "Friday")
            {
                if(typeOfGroup == "Students")
                {
                    if (groupOfPeople >= 30)
                    {
                        price = 8.45m;
                        totalPrice = price * groupOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.15m);
                    }
                    else
                    {
                        price = 8.45m;
                        totalPrice = price * groupOfPeople;
                    }
                }
                else if(typeOfGroup == "Business")
                {
                    if (groupOfPeople >= 100)
                    {
                        price = 10.90m;
                        totalPrice = price * (groupOfPeople-10);
                    }
                    else
                    {
                        price = 10.90m;
                        totalPrice = price * groupOfPeople;
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    if (groupOfPeople >= 10 && groupOfPeople <= 20)
                    {
                        price = 15m;
                        totalPrice = price * groupOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.05m);
                    }
                    else
                    {
                        price = 15m;
                        totalPrice = price * groupOfPeople;
                    }
                }
            }
            else if(dayOfWeek == "Saturday")
            {
                if (typeOfGroup == "Students")
                {
                    if (groupOfPeople >= 30)
                    {
                        price = 9.80m;
                        totalPrice = price * groupOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.15m);
                    }
                    else
                    {
                        price = 9.80m;
                        totalPrice = price * groupOfPeople;
                    }
                }
                else if (typeOfGroup == "Business")
                {
                    if (groupOfPeople >= 100)
                    {
                        price = 15.60m;
                        totalPrice = price * (groupOfPeople - 10);
                    }
                    else
                    {
                        price = 15.60m;
                        totalPrice = price * groupOfPeople;
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    if (groupOfPeople >= 10 && groupOfPeople <= 20)
                    {
                        price = 20m;
                        totalPrice = price * groupOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.05m);
                    }
                    else
                    {
                        price = 20m;
                        totalPrice = price * groupOfPeople;
                    }
                }
            }
            else if(dayOfWeek == "Sunday")
            {
                if (typeOfGroup == "Students")
                {
                    if (groupOfPeople >= 30)
                    {
                        price = 10.46m;
                        totalPrice = price * groupOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.15m);
                    }
                    else
                    {
                        price = 10.46m;
                        totalPrice = price * groupOfPeople;
                    }
                }
                else if (typeOfGroup == "Business")
                {
                    if (groupOfPeople >= 100)
                    {
                        price = 16m;
                        totalPrice = price * (groupOfPeople - 10);
                    }
                    else
                    {
                        price = 16m;
                        totalPrice = price * groupOfPeople;
                    }
                }
                else if (typeOfGroup == "Regular")
                {
                    if (groupOfPeople >= 10 && groupOfPeople <= 20)
                    {
                        price = 22.50m;
                        totalPrice = price * groupOfPeople;
                        totalPrice = totalPrice - (totalPrice * 0.05m);
                    }
                    else
                    {
                        price = 22.50m;
                        totalPrice = price * groupOfPeople;
                    }
                }
            }
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
