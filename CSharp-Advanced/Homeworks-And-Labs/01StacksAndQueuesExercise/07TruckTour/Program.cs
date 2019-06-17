using System;
using System.Linq;
using System.Collections.Generic;

namespace _07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());

            var difference = new Queue<int>();

            for (int i = 1; i <= petrolPumps; i++)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int amountOfPetrol = tokens[0];
                int distance = tokens[1];

                difference.Enqueue(amountOfPetrol - distance);
            }

            int index = 0;

            while (true)
            {
                var copyDifference = new Queue<int>(difference);

                int fuel = int.MinValue;

                while (copyDifference.Any())
                {
                    int currentDiffernce = copyDifference.Peek();

                    if (currentDiffernce > 0 && fuel == int.MinValue)
                    {
                        fuel = copyDifference.Dequeue();
                        difference.Enqueue(difference.Dequeue());
                    }
                    else if (currentDiffernce < 0 && fuel == int.MinValue)
                    {
                        copyDifference.Enqueue(copyDifference.Dequeue());
                        difference.Enqueue(difference.Dequeue());
                        index++;
                    }
                    else
                    {
                        fuel += copyDifference.Dequeue();

                        if(fuel < 0)
                        {
                            break;
                        }
                    }
                }

                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }

                index++;
            }
        }
    }
}
