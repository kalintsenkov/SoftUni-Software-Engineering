using System;
using System.Linq;
using System.Collections.Generic;

namespace _02BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToAdd = commandNumbers[0];
            int elementsToRemove = commandNumbers[1];
            int elementToLookFor = commandNumbers[2];

            var queue = new Queue<int>();

            for (int i = 0; i < elementsToAdd; i++)
            {
                queue.Enqueue(input[i]);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Any())
                {
                    Console.WriteLine(queue.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
