using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main()
        {
            var inputNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(inputNumbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
