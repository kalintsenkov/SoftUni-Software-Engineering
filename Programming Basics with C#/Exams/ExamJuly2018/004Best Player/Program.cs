using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();

            int scoredGoals = 0;
            int bestGoals = int.MinValue;
            string bestPlayer = "";

            while (playerName != "END")
            {
                scoredGoals = int.Parse(Console.ReadLine());
                if (scoredGoals > bestGoals)
                {
                    bestGoals = scoredGoals;
                    bestPlayer = playerName;
                }
                if(scoredGoals >= 10)
                {
                    break;
                }
                playerName = Console.ReadLine();
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (scoredGoals >= 3)
            {
               Console.WriteLine($"He has scored {bestGoals} goals and made a hat-trick !!!");
            }
            else
            {
               Console.WriteLine($"He has scored {bestGoals} goals.");
            }
        }
    }
}
