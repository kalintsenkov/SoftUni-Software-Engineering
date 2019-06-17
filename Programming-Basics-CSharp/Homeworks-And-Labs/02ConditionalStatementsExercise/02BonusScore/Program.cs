using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = int.Parse(Console.ReadLine());

            double bonusPoints = 0;

            if(points <= 100)
            {
                bonusPoints = bonusPoints + 5;
            }
            else if(points > 100 && points < 1000)
            {
                bonusPoints = points * 0.20;
            }
            else if(points >= 1000)
            {
                bonusPoints = points * 0.10;
            }

            if (points % 2 == 0)
            {
                bonusPoints++;
            }
            else if (points % 10 == 5)
            {
                bonusPoints = bonusPoints + 2;
            }
            Console.WriteLine(bonusPoints);
            Console.WriteLine(points+bonusPoints); 
        }
    }
}
