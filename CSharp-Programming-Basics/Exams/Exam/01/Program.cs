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
            double baklavaPrice = double.Parse(Console.ReadLine());
            double muffinPrice = double.Parse(Console.ReadLine());
            double sholenInKg = double.Parse(Console.ReadLine());
            double sweetsInKg = double.Parse(Console.ReadLine());
            int biscuitsInKg = int.Parse(Console.ReadLine());

            double sholenPrice = baklavaPrice + baklavaPrice * 0.60;
            double totalSholen = sholenInKg * sholenPrice;
            double sweetsPrice = muffinPrice + muffinPrice * 0.80;
            double totalSweets = sweetsInKg * sweetsPrice;
            double totalBiscuits = (double)biscuitsInKg * 7.50;

            double totalMoney = totalSholen + totalSweets + totalBiscuits;

            Console.WriteLine($"{totalMoney:F2}");

        }
    }
}
