using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05GameInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int matches = int.Parse(Console.ReadLine());

            double minutes = 0;
            double minutesSum = 0;
            double averageMinutes = 0;
            int extraTimeCounter = 0;
            int penaltyCounter = 0;

            for (int i = 1; i <= matches; i++)
            {
                minutes = int.Parse(Console.ReadLine());
                minutesSum = minutesSum + minutes;
                averageMinutes = minutesSum / matches;
                if (minutes > 90 && minutes <= 120)
                {
                    extraTimeCounter++;
                }
                if(minutes > 120)
                {
                    penaltyCounter++;
                }
            }
            Console.WriteLine($"{team} has played {minutesSum} minutes. Average minutes per game: {averageMinutes:F2}");
            Console.WriteLine($"Games with penalties: {penaltyCounter}");
            Console.WriteLine($"Games with additional time: {extraTimeCounter}");
        }
    }
}
