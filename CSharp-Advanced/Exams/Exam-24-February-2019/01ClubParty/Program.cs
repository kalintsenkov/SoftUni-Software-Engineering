using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var reservations = new Stack<string>(input);

            var halls = new Queue<string>();
            var allGroups = new List<int>();

            while (reservations.Any())
            {
                string currentItem = reservations.Pop();

                if (int.TryParse(currentItem, out int result))
                {
                    if (allGroups.Sum() + result > maxCapacity && halls.Any())
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                    }

                    if (halls.Any())
                    {
                        allGroups.Add(result);
                    }
                }
                else
                {
                    halls.Enqueue(currentItem);
                }
            }
        }
    }
}
