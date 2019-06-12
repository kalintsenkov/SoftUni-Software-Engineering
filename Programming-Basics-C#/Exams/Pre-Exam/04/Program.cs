using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            int budgetForSinger = int.Parse(Console.ReadLine());

            int numberPeople = 0;
            int peopleSum = 0;
            int money = 0;
            int moneySum = 0;

            string input = Console.ReadLine();

            while (input != "The restaurant is full")
            {
                numberPeople = int.Parse(input);
                peopleSum = peopleSum + numberPeople;
                if (numberPeople < 5)
                {
                    money = numberPeople * 100;
                }
                else if (numberPeople >= 5)
                {
                    money = numberPeople * 70;
                }
                moneySum = moneySum + money;
                input = Console.ReadLine();
            }

            if (moneySum >= budgetForSinger)
            {
                Console.WriteLine($"You have {peopleSum} guests and {moneySum-budgetForSinger} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {peopleSum} guests and {moneySum} leva income, but no singer.");
            }
        }
    }
}
