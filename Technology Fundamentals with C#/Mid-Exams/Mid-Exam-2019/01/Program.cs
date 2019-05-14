using System;
using System.Linq;
using System.Collections.Generic;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            double priceOfFuel = double.Parse(Console.ReadLine());
            double foodExpensesForOne = double.Parse(Console.ReadLine());
            double priceForRoom = double.Parse(Console.ReadLine());

            decimal totalFoodExpenses = (decimal)foodExpensesForOne * groupOfPeople * daysOfTrip;
            
            decimal totalPriceForHotel = (decimal)priceForRoom * groupOfPeople * daysOfTrip;
            
            if (groupOfPeople > 10)
            {
                totalPriceForHotel = totalPriceForHotel - totalPriceForHotel * 0.25m;
            }

            decimal currentExpenses = totalFoodExpenses + totalPriceForHotel;

            for (int day = 1; day <= daysOfTrip; day++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());

                currentExpenses = currentExpenses + (decimal)(travelledDistance * priceOfFuel);

                if(day % 3 == 0)
                {
                    currentExpenses = currentExpenses + currentExpenses * 0.4m;
                }
                else if(day % 5 == 0)
                {
                    currentExpenses = currentExpenses + currentExpenses * 0.4m;
                }
                else if(day % 7 == 0)
                {
                    decimal receivedMoney = currentExpenses / groupOfPeople;
                    currentExpenses -= receivedMoney;
                }

                if(currentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {currentExpenses - budget:f2}$ more.");
                    return;
                }
            }

            if(budget >= currentExpenses)
            {
                Console.WriteLine($"You have reached the destination. You have {budget - currentExpenses:f2}$ budget left.");
            }
            else
            {
                Console.WriteLine($"Not enough money to continue the trip. You need {currentExpenses - budget:f2}$ more.");
            }
        }
    }
}
