using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace _12SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalIncome = 0;

            while (input != "end of shift")
            {
                string pattern = @"%(?<customer>[A-Z][a-z]+)%([^|$%.]*)<(?<product>\w+)>([^|$%.]*)\|(?<count>\d+)\|([^|$%.]*?)(?<price>\d+.*\d+)\$";

                var validLines = Regex.Matches(input, pattern);

                foreach (Match match in validLines)
                {
                    string customerName = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double totalPrice = count * price;

                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
