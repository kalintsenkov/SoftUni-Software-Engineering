using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001StadiumIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSectors = int.Parse(Console.ReadLine());
            int stadiumCapacity = int.Parse(Console.ReadLine());
            double OneTicketPrice = double.Parse(Console.ReadLine());

            double income = stadiumCapacity * OneTicketPrice;
            double incomeForOneSector = income / numberSectors;
            double moneyForCharity = (income - (incomeForOneSector * 0.75)) / 8;

            Console.WriteLine($"Total income - {income:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
        }
    }
}
