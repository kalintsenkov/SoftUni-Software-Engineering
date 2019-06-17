using System;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        public static void Main()
        {
            var createCommand = Console.ReadLine()
                   .Split(new string[] { "Create", " " }, StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

            var listyIterator = new ListyIterator<string>(createCommand);

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (command == "Print")
                {
                    Console.WriteLine(listyIterator.Print());
                }
                else if(command == "PrintAll")
                {
                    Console.WriteLine(listyIterator.PrintAll());
                }

                input = Console.ReadLine();
            }
        }
    }
}
