using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            int penalty = 0;
            int penaltySum = 0;

            for (int i = 0; i < n; i++)
            {
                string website = Console.ReadLine();
                if (website == "Facebook")
                {
                    penalty = 150;
                    salary = salary - penalty;
                }
                else if (website == "Instagram")
                {
                    penalty = 100;
                    salary = salary - penalty;
                }
                else if (website == "Reddit")
                {
                    penalty = 50;
                    salary = salary - penalty;
                }
                penaltySum = penaltySum + penalty;
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                salary = salary + penaltySum;
                Console.WriteLine(salary - penaltySum);
            }
        }
    }
}