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
            double moneyToCollect = double.Parse(Console.ReadLine());
            int numFantasyBooks = int.Parse(Console.ReadLine());
            int numHorrorBooks = int.Parse(Console.ReadLine());
            int numRomanticBooks = int.Parse(Console.ReadLine());

            double sumOfSellings = numFantasyBooks * 14.90 + numHorrorBooks * 9.80 + numRomanticBooks * 4.30;
            double dds = sumOfSellings * 0.20;
            double sumAfterDds = sumOfSellings - dds;

            double money = sumAfterDds - moneyToCollect;
            double discount = Math.Floor(money * 0.10);
            double moneyForCharity = money - discount;
            double totalMoney = moneyToCollect + moneyForCharity;

            if (sumAfterDds >= moneyToCollect)
            {
                Console.WriteLine($"{totalMoney:F2} leva donated.");
                Console.WriteLine($"Sellers will receive {discount} leva.");
            }
            else
            {
                Console.WriteLine($"{(moneyToCollect-sumAfterDds):F2} money needed.");
            }
        }
    }
}
