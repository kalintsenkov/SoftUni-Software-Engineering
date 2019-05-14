using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005ProjectPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());
            double prize = double.Parse(Console.ReadLine());

            double moneyPrize = 0;
            double points = 0;
            double pointsSum = 0;

            for (int i = 1; i <= parts; i++)
            {
                points = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    points = points * 2;
                }
                pointsSum = pointsSum + points;
            }
            moneyPrize = prize * pointsSum;
            Console.WriteLine($"The project prize was {moneyPrize:F2} lv.");
        }
    }
}
