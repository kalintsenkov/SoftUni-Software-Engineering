using System;
using System.Collections.Generic;
using System.Linq;

namespace _12CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var bottlesWithWater = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var cups = new Queue<int>(cupsCapacity);
            var bottles = new Stack<int>(bottlesWithWater);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCupValue = cups.Peek();
                int currentBottleValue = bottles.Peek();

                if (currentBottleValue >= currentCupValue)
                {
                    if (currentCupValue - currentBottleValue <= 0)
                    {
                        cups.Dequeue();
                    }

                    wastedWater += currentBottleValue - currentCupValue;

                    bottles.Pop();
                }
                else
                {
                    while (currentCupValue > 0)
                    {
                        currentCupValue -= bottles.Pop();
                    }

                    wastedWater += Math.Abs(currentCupValue);

                    cups.Dequeue();
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
