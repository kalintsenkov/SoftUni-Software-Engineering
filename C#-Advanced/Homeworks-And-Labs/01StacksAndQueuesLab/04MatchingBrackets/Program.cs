using System;
using System.Collections.Generic;

namespace _04MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var symbols = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    symbols.Push(i);
                }
                else if (input[i] == ')')
                {
                    int openBracketIndex = symbols.Pop();

                    Console.WriteLine(input.Substring(openBracketIndex, i - openBracketIndex + 1));
                }
            }
        }
    }
}
