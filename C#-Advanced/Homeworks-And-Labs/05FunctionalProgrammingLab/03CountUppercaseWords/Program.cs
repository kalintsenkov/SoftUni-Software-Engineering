using System;
using System.Linq;

namespace _03CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0]))
                .ToList();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
