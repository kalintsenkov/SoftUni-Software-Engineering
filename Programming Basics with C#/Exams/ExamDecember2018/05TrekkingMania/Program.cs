using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberGroups = int.Parse(Console.ReadLine());

            double people = 0;
            double peopleSum = 0;

            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;

            double p1Percent = 0;
            double p2Percent = 0;
            double p3Percent = 0;
            double p4Percent = 0;
            double p5Percent = 0;


            for (int i = 1; i <= numberGroups; i++)
            {
                people = int.Parse(Console.ReadLine());
                peopleSum = peopleSum + people;
                if(people >= 1 && people <= 5)
                {
                    p1 = p1 + people;
                }
                else if (people >= 6 && people <= 12)
                {
                    p2 = p2 + people;
                }
                else if (people >= 13 && people <= 25)
                {
                    p3 = p3 + people;
                }
                else if (people >= 26 && people <= 40)
                {
                    p4 = p4 + people;
                }
                else if (people >= 41)
                {
                    p5 = p5 + people;
                }
            }
            p1Percent = p1 / peopleSum * 100;
            p2Percent = p2 / peopleSum * 100;
            p3Percent = p3 / peopleSum * 100;
            p4Percent = p4 / peopleSum * 100;
            p5Percent = p5 / peopleSum * 100;

            Console.WriteLine($"{p1Percent:F2}%");
            Console.WriteLine($"{p2Percent:F2}%");
            Console.WriteLine($"{p3Percent:F2}%");
            Console.WriteLine($"{p4Percent:F2}%");
            Console.WriteLine($"{p5Percent:F2}%");
        }
    }
}
