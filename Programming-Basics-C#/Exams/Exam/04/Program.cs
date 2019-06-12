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
            string command = Console.ReadLine();

            int age = 0;
            int kidsCounter = 0;
            int adultsCounter = 0;
            int moneyForToys = 0;
            int moneyForSweaters = 0;

            while (command != "Christmas")
            {
                age = int.Parse(command);

                if (age <= 16)
                {
                    kidsCounter++;
                    moneyForToys = kidsCounter * 5;
                }
                else if (age > 16)
                {
                    adultsCounter++;
                    moneyForSweaters = adultsCounter * 15;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Number of adults: {adultsCounter}");
            Console.WriteLine($"Number of kids: {kidsCounter}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
