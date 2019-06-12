using System;
using System.Linq;
using System.Collections.Generic;

namespace _01BasicStackOperations
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

            int elementsToPush = commandNumbers[0];
            int elementsToPop = commandNumbers[1];
            int elementToLookFor = commandNumbers[2];

            var stack = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 1; i <= elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
