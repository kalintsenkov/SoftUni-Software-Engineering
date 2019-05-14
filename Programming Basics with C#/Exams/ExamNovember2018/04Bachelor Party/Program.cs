using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestPrice = int.Parse(Console.ReadLine());

            int numberPeopleInGroup = 0;
            int peopleSum = 0;
            int groupLessThanFivePeople = 0;
            int groupMoreThanFivePeople = 0;
            int totalSum = 0;

            string command = Console.ReadLine();

            while (command != "The restaurant is full")
            {
                numberPeopleInGroup = int.Parse(command);
                peopleSum = peopleSum + numberPeopleInGroup;

                if (numberPeopleInGroup < 5)
                {
                    groupLessThanFivePeople = groupLessThanFivePeople + (numberPeopleInGroup * 100);
                }
                if (numberPeopleInGroup >= 5)
                {
                    groupMoreThanFivePeople = groupMoreThanFivePeople + (numberPeopleInGroup * 70);
                }
                totalSum = groupLessThanFivePeople + groupMoreThanFivePeople;

                command = Console.ReadLine();
            }

            if (totalSum >= guestPrice)
            {
                Console.WriteLine($"You have {peopleSum} guests and {totalSum - guestPrice} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {peopleSum} guests and {totalSum} leva income, but no singer.");
            }
        }
    }
}
