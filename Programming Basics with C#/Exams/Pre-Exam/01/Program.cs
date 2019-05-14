using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodMoney = double.Parse(Console.ReadLine());
            double souvenirsMoney = double.Parse(Console.ReadLine());
            double hotelMoney = double.Parse(Console.ReadLine());

            double benzinNeeded = (double)420 / 100 * 7;

            double moneyForBenzin = benzinNeeded * 1.85;
            double moneyForFoodAndSouv = (3 * foodMoney) + (3 * souvenirsMoney);

            double firstDay = hotelMoney * 0.9;
            double secondDay = hotelMoney * 0.85;
            double thirdDay = hotelMoney * 0.8;

            double moneySum = moneyForBenzin + moneyForFoodAndSouv + firstDay + secondDay + thirdDay;
            Console.WriteLine($"Money needed: {moneySum:F2}");
        }
    }
}
