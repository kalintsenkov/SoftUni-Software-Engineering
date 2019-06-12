using System;
using System.Collections.Generic;
using System.Linq;

namespace _06HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var allChildren = Console.ReadLine()
                .Split()
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            var children = new Queue<string>(allChildren);

            int childCount = 0;

            while (children.Count > 1)
            {
                string currentChild = children.Dequeue();

                childCount++;

                if (childCount % n != 0)
                {
                    children.Enqueue(currentChild);
                }
                else
                {
                    Console.WriteLine($"Removed {currentChild}");
                }
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
