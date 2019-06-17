using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());

            double metersToSwim = meters * secondsForOneMeter;
            double secondsAdded = (Math.Floor(meters / 15)) * 12.5;
            double totalTime = metersToSwim + secondsAdded;


            if (recordInSeconds > totalTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                double timeNeededForSuccess = totalTime - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {timeNeededForSuccess:F2} seconds slower.");
            }
        }
    }
}
