using System;
using System.Linq;
using System.Collections.Generic;

namespace _06ListManipulationBasics
{
    class Program
    {
        static void Main()
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

                string command = commands[0];

                if(command == "Add")
                {
                    int numberToAdd = int.Parse(commands[1]);
                    numbers.Add(numberToAdd);
                }
                else if(command == "Remove")
                {
                    int numberToRemove = int.Parse(commands[1]);
                    numbers.Remove(numberToRemove);
                }
                else if(command == "RemoveAt")
                {
                    int index = int.Parse(commands[1]);
                    numbers.RemoveAt(index);
                }
                else if(command == "Insert")
                {
                    int numberToInsert = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);
                    numbers.Insert(index, numberToInsert);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
