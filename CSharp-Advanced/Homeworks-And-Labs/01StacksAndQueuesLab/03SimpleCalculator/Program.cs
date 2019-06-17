using System;
using System.Collections.Generic;
using System.Linq;

namespace _03SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToArray();

            var symbols = new Stack<string>(input.Reverse());

            int result = int.Parse(symbols.Pop());

            while (symbols.Any())
            {
                string nextSymbol = symbols.Pop();

                if (nextSymbol == "+")
                {
                    result += int.Parse(symbols.Pop());
                }
                else if (nextSymbol == "-")
                {
                    result -= int.Parse(symbols.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}
