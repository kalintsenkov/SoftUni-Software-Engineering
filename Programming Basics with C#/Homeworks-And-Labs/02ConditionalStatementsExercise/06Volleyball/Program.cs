using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsInHometown = double.Parse(Console.ReadLine());

            if(year == "leap")
            {
                double weekendsInSofia = 48 - weekendsInHometown;
                double gamesInWeekends = weekendsInSofia * (3.0 / 4);
                double gamesInHometown = weekendsInHometown;
                double gamesInHolidays = holidays * (2.0 / 3);
                double totalGames = gamesInWeekends + gamesInHometown + gamesInHolidays;
                double moreVolleyball = totalGames * 0.15;
                double totalGamesForYear = totalGames + moreVolleyball;
                Console.WriteLine(Math.Truncate(totalGamesForYear));
                
            }
            else if(year == "normal")
            {
                double weekendsInSofia = 48 - weekendsInHometown;
                double gamesInWeekends = weekendsInSofia * (3.0 / 4);
                double gamesInHometown = weekendsInHometown;
                double gamesInHolidays = holidays * (2.0 / 3);
                double totalGames = gamesInWeekends + gamesInHometown + gamesInHolidays;
                Console.WriteLine(Math.Truncate(totalGames));
            }
        }
    }
}
