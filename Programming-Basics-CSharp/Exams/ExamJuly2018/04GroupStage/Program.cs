using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04GroupStage
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            int playedMatches = int.Parse(Console.ReadLine());

            int goalsScored = 0;
            int goalsConceded = 0;
            int goalDiff = 0;
            int totalGoalDiff = 0;
            int points = 0;
            int totalScoredGoals = 0;
            int totalConcededGoals = 0;

            for (int i = 0; i < playedMatches; i++)
            {
                goalsScored = int.Parse(Console.ReadLine());
                goalsConceded = int.Parse(Console.ReadLine());

                totalScoredGoals = totalScoredGoals + goalsScored;
                totalConcededGoals = totalConcededGoals + goalsConceded;

                goalDiff = goalsScored - goalsConceded;
                totalGoalDiff = totalGoalDiff + goalDiff;

                if (goalsScored > goalsConceded)
                {
                    points = points + 3;
                }
                else if(goalsScored == goalsConceded)
                {
                    points = points + 1;
                }
                else
                {
                    points = points + 0;
                }
            }

            if (totalScoredGoals >= totalConcededGoals)
            {
                Console.WriteLine($"{team} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {totalGoalDiff}.");
            }
            else
            {
                Console.WriteLine($"{team} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {totalGoalDiff}.");
            }
        }   
    }
}
