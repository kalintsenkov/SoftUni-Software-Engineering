using System;
using System.Collections.Generic;
using System.Linq;

namespace _02ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> commands = input
                    .Split()
                    .ToList();

                string manipulation = commands[0];

                if (manipulation == "Delete")
                {
                    int element = int.Parse(commands[1]);
                    numbers.RemoveAll(x => x == element);
                }
                else if (manipulation == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int position = int.Parse(commands[2]);

                    numbers.Insert(position, element);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
