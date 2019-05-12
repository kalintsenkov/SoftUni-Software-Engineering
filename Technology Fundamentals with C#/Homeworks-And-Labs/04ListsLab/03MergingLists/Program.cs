using System;
using System.Linq;
using System.Collections.Generic;

namespace _03MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> result = new List<int>();

            int minCount = Math.Min(firstNumbers.Count, secondNumbers.Count);

            for (int i = 0; i < minCount; i++)
            {
                result.Add(firstNumbers[i]);
                result.Add(secondNumbers[i]);
            }

            if(minCount == firstNumbers.Count)
            {
                for (int i = minCount; i < secondNumbers.Count; i++)
                {
                    result.Add(secondNumbers[i]);
                }
            }
            else
            {
                for (int i = minCount; i < firstNumbers.Count; i++)
                {
                    result.Add(firstNumbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
