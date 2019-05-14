using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _07MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string dates = Console.ReadLine();

            var matchDates = Regex.Matches(dates, @"\b(?<day>[0-9]{2})([-./])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b");

            foreach (Match date in matchDates)
            {
                Console.WriteLine($"Day: {date.Groups["day"].Value}, Month: {date.Groups["month"].Value}, Year: {date.Groups["year"].Value}");
            }
        }
    }
}
