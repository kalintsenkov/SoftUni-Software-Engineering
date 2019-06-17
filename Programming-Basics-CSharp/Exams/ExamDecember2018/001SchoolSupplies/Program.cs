using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001SchoolSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPens = int.Parse(Console.ReadLine());
            int numberMarkers = int.Parse(Console.ReadLine());
            double literForCleaning = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double totalPens = numberPens * 5.80;
            double totalMarkers = numberMarkers * 7.20;
            double cleaning = literForCleaning * 1.20;
            double totalMoney = totalPens + totalMarkers + cleaning;
            double moneyWithDiscount = totalMoney - ((totalMoney * discount) / 100);

            Console.WriteLine($"{moneyWithDiscount:F3}");
        }
    }
}
