using System;
using System.Linq;
using System.Collections.Generic;

namespace _02StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var stackNumbers = new Stack<int>(numbers);

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                var tokens = input
                    .Split()
                    .ToArray();

                string command = tokens[0];

                if (command == "add")
                {
                    int firstNumber = int.Parse(tokens[1]);
                    int secondNumber = int.Parse(tokens[2]);

                    stackNumbers.Push(firstNumber);
                    stackNumbers.Push(secondNumber);
                }
                else if (command == "remove")
                {
                    int count = int.Parse(tokens[1]);

                    if (stackNumbers.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stackNumbers.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stackNumbers.Sum()}");
        }
    }
}
