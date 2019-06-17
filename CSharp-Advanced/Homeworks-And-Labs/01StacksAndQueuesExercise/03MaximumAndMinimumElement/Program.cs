using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _03MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var sb = new StringBuilder();

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputLines; i++)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int command = tokens[0];

                if (command == 1) // push the element into the stack
                {
                    int elementToPush = tokens[1];

                    stack.Push(elementToPush);
                }
                else if (command == 2) // delete the element at the top of the stack
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (command == 3) // print the maximum element in the stack
                {
                    if (stack.Count > 0)
                    {
                        sb.AppendLine(stack.Max().ToString());
                    }
                }
                else if (command == 4) // print the minimum element in the stack
                {
                    if (stack.Count > 0)
                    {
                        sb.AppendLine(stack.Min().ToString());
                    }
                }
            }

            sb.AppendLine(string.Join(", ", stack));
            Console.Write(sb);
        }
    }
}
