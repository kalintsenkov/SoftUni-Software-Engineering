using System;
using System.Collections.Generic;
using System.Linq;

namespace _04EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberOfLines; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 1);
                }
                else
                {
                    numbers[number]++;
                }
            }

            foreach (var kvp in numbers.Where(x => x.Value % 2 == 0))
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
