using System;
using System.Collections.Generic;
using System.Linq;

namespace _05FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothesValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothesValues);

            int sum = 0;
            int rackCounter = 1;

            while (stack.Any())
            {
                int currentValue = stack.Peek();

                if(sum + currentValue <= rackCapacity)
                {
                    sum += currentValue;
                    stack.Pop();
                }
                else
                {
                    sum = 0;
                    rackCounter++;
                }
            }

            Console.WriteLine(rackCounter);
        }
    }
}
