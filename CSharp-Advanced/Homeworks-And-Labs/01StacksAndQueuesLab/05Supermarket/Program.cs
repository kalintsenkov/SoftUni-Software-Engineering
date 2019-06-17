using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var queue = new Queue<string>();

            int peopleCount = 0;

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }

                    peopleCount = 0;
                }
                else
                {
                    queue.Enqueue(input);
                    peopleCount++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{peopleCount} people remaining.");
        }
    }
}
