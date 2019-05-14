using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());

            double metersToWin = meters * timeForOneMeter;
            double slowingTime = Math.Floor(meters / 50) * 30;
            double timeSum = metersToWin + slowingTime;

            if (recordInSeconds <= timeSum)
            {
                double timeNeeded = timeSum - recordInSeconds;
                Console.WriteLine($"No! He was {timeNeeded:F2} seconds slower.");
            }
            else
            {

                Console.WriteLine($"Yes! The new record is {timeSum:F2} seconds.");
            }
        }
    }
}
