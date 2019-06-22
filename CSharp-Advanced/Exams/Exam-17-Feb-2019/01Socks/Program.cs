using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Socks
{
    public class Program
    {
        public static void Main()
        {
            var left = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var right = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var leftSocks = new Stack<int>(left);
            var rightSocks = new Queue<int>(right);

            var pairs = new Queue<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int curretLeftSock = leftSocks.Peek();
                int currentRightSock = rightSocks.Peek();

                if (curretLeftSock > currentRightSock)
                {
                    pairs.Enqueue(leftSocks.Pop() + rightSocks.Dequeue());
                }
                else if (currentRightSock > curretLeftSock)
                {
                    leftSocks.Pop();
                }
                else
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSocks.Pop() + 1);
                }
            }

            if (pairs.Any())
            {
                Console.WriteLine(pairs.Max());
                Console.WriteLine(string.Join(" ", pairs));
            }
        }
    }
}
