using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int climedMeters = 0;
            int daysCount = 1;
            int metersSum = 5364;

            while (input != "END")
            {
                climedMeters = int.Parse(Console.ReadLine());
                if(input == "Yes")
                {
                    daysCount++;
                }
                metersSum = metersSum + climedMeters;
                if (metersSum >= 8848)
                {
                    Console.WriteLine($"Goal reached for {daysCount} days!");
                    break;
                }
                if (daysCount > 5)
                {
                    break;
                }
                input = Console.ReadLine();
            }

            if(input == "END")
            {
                if (metersSum >= 8848)
                {
                    Console.WriteLine($"Goal reached for {daysCount} days!");
                }
                else
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine($"{metersSum}");
                }
            }

            if(daysCount > 5)
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{metersSum-climedMeters}");
            }
        }
    }
}
