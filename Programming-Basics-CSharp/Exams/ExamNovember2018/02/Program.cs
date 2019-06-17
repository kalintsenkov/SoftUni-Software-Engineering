using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double waterInLiters = double.Parse(Console.ReadLine());
            double wineInLiters = double.Parse(Console.ReadLine());
            double champagneInLiters = double.Parse(Console.ReadLine());
            double whiskeyInLiters = double.Parse(Console.ReadLine());

            double champagnePrice = whiskeyPrice * 0.5;
            double winePrice = champagnePrice * 0.4;
            double waterPrice = champagnePrice * 0.1;

            double champagneTotalPrice = champagneInLiters * champagnePrice;
            double wineTotalPrice = wineInLiters * winePrice;
            double waterTotalPrice = waterInLiters * waterPrice;
            double whiskeyTotalPrice = whiskeyInLiters * whiskeyPrice;

            double totalSum = champagneTotalPrice + wineTotalPrice + waterTotalPrice + whiskeyTotalPrice;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
