using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var symbols = new Stack<char>();

            foreach (var symbol in input)
            {
                symbols.Push(symbol);
            }

            while (symbols.Count != 0)
            {
                Console.Write(symbols.Pop());
            }
        }
    }
}
