using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002BeerAndChips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int numberBeers = int.Parse(Console.ReadLine());
            int numberChips = int.Parse(Console.ReadLine());

            double beerTotal = 1.20 * numberBeers;
            double chipsPrice = beerTotal * 0.45;
            double chipsTotal = Math.Ceiling(chipsPrice * numberChips);
            double totalSum = beerTotal + chipsTotal;

            if (budget >= totalSum)
            {
                Console.WriteLine($"{name} bought a snack and has {(budget-totalSum):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {(totalSum-budget):F2} more leva!");
            }
        }
    }
}
