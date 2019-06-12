using System;
using System.Collections.Generic;

namespace _08BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var open = new Stack<char>();

            bool isBalanced = true;

            foreach (char symbol in input)
            {
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    open.Push(symbol);
                }
                else
                {
                    if (open.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    char lastSymbol = open.Pop();

                    if (symbol == ')' && lastSymbol != '(')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (symbol == '}' && lastSymbol != '{')
                    {
                        isBalanced = false;
                        break;
                    }
                    else if (symbol == ']' && lastSymbol != '[')
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
