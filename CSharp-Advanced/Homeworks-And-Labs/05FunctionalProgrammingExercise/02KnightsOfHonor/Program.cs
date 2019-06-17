using System;
using System.Linq;

namespace _02KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Action<string> sirAction = n => Console.WriteLine($"Sir {n}");

            foreach (var name in names)
            {
                sirAction(name);
            }
        }
    }
}
