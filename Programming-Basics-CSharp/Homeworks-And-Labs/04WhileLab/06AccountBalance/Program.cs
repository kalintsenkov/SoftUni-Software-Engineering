using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06AccountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPayments = int.Parse(Console.ReadLine());

            decimal inputMoney = 0;
            decimal totalMoney = 0;

            while (countPayments > 0)
            {
                inputMoney = decimal.Parse(Console.ReadLine());

                if (inputMoney < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                countPayments--;
                Console.WriteLine($"Increase: {inputMoney:F2}");
                totalMoney = totalMoney + inputMoney;
            }
            Console.WriteLine($"Total: {totalMoney:F2}");
        }
    }
}
