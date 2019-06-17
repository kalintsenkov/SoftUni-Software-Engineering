using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input.Contains("Push"))
                {
                    var numbers = input
                        .Split(new string[] { "Push", ",", " "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    stack.Push(numbers);
                }
                else if(input.Contains("Pop"))
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
