using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstBrother = double.Parse(Console.ReadLine());
            double secondBrother = double.Parse(Console.ReadLine());
            double thirdBrother = double.Parse(Console.ReadLine());
            double fatherTime = double.Parse(Console.ReadLine());

            double sumTime = 1 / (1 / firstBrother + 1 / secondBrother + 1 / thirdBrother);
            double relaxTime = sumTime * 1.15;
            double timeLeft = fatherTime - relaxTime;
            Console.WriteLine($"Cleaning time: {relaxTime:F2}");

            if (timeLeft > 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
            }
            else
            {
                double timeNeeded = Math.Abs(timeLeft);
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeNeeded)} hours.");
            }
        }
    }
}
