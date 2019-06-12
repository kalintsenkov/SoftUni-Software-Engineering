using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vuvedi budget: ");
            int budget = int.Parse(Console.ReadLine());

            int sum = 0;

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                for (int i = 0; i <= command.Length - 1; i++)
                {
                    sum = sum + command[i];
                }

                if (budget >= sum)
                {
                    Console.WriteLine($"Item successfully purchased!");
                }
                else 
                {
                    Console.WriteLine($"Not enough money!");
                    return;
                }
                budget = budget - sum;
                sum = 0;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Money left: {budget}");
        }
    }
}
