using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01TripToWorldCup
{
    class Program
    {
        static void Main(string[] args)
        {
            double oneWayTicketPrice = double.Parse(Console.ReadLine());
            double returnTicketPrice = double.Parse(Console.ReadLine());
            double matchTicketPrice = double.Parse(Console.ReadLine());
            int numberMatches = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double ticketsPrice = 6 * (oneWayTicketPrice + returnTicketPrice);
            double ticketsAfterDiscount = ticketsPrice - (ticketsPrice * (discount/100));
            double sumMatchTicketPrice = 6 * numberMatches * matchTicketPrice;
            double moneyToPay = ticketsAfterDiscount + sumMatchTicketPrice;
            double eachFriendMoneyToPay = moneyToPay / 6;

            Console.WriteLine($"Total sum: {moneyToPay:F2} lv.");
            Console.WriteLine($"Each friend has to pay {eachFriendMoneyToPay:F2} lv.");
        }
    }
}
