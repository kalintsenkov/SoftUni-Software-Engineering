using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washerPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int money = 0;
            int moneySum = 0;
            int moneyStoolenFromBrother = 0;
            int toyCount = 0;
            int toySelled = 0;
            double moneyLeft = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money = money + 10;
                    moneySum = moneySum + money;
                    moneyStoolenFromBrother++;
                }
                else
                {
                    toyCount++;
                }
                toySelled = toyCount * toyPrice;
                moneyLeft = moneySum + toySelled - moneyStoolenFromBrother;
            }

            if (moneyLeft >= washerPrice)
            {
                Console.WriteLine($"Yes! {(moneyLeft-washerPrice):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(washerPrice-moneyLeft):F2}");
            }
        }
    }
}
