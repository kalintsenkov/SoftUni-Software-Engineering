using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004WeddingDecoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            double flowersSum = 0;
            double balloonsSum = 0;
            double candlesSum = 0;
            double ribbonSum = 0;
            double totalSum = 0;
            int flowersCount = 0;
            int balloonsCount = 0;
            int candlesCount = 0;
            int ribbonCount = 0;

            string stock = Console.ReadLine();

            while (stock != "stop")
            {
                int numberStocks = int.Parse(Console.ReadLine());

                if(stock == "flowers")
                {
                    flowersSum = flowersSum + (numberStocks * 1.5);
                    flowersCount = flowersCount + numberStocks;
                }
                if(stock == "balloons")
                {
                    balloonsSum = balloonsSum + (numberStocks * 0.1);
                    balloonsCount = balloonsCount + numberStocks;
                }
                if (stock == "candles")
                {
                    candlesSum = candlesSum + (numberStocks * 0.5);
                    candlesCount = candlesCount + numberStocks;
                }
                if (stock == "ribbon")
                {
                    ribbonSum = ribbonSum + (numberStocks * 2);
                    ribbonCount = ribbonCount + numberStocks;
                }

                totalSum = flowersSum + balloonsSum + candlesSum + ribbonSum;
                
                if (budget <= totalSum)
                {
                    Console.WriteLine("All money is spent!");
                    break;
                }
                stock = Console.ReadLine();
            }

            if (stock == "stop")
            {
                Console.WriteLine($"Spend money: {totalSum:F2}");
                Console.WriteLine($"Money left: {budget-totalSum:F2}");
            }
            Console.WriteLine($"Purchased decoration is {balloonsCount} balloons, {ribbonCount} m ribbon, {flowersCount} flowers and {candlesCount} candles.");
        }
    }
}
