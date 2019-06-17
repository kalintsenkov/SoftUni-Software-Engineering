using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var word in words)
            {
                int repeat = word.Length;

                for (int j = 0; j < repeat; j++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
