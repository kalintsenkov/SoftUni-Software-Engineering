using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double moneySum = 0;
            double money = 0;

            while (input != "End")
            {
                double budget = double.Parse(Console.ReadLine());
                while (budget > moneySum)
                {
                    money = double.Parse(Console.ReadLine());
                    moneySum = moneySum + money;
                    if (moneySum >= budget)
                    {
                        Console.WriteLine($"Going to {input}!");
                    }
                }
                moneySum = 0;
                input = Console.ReadLine();
            }
        }
    }
}
