using System;
using System.Linq;
using System.Collections.Generic;

namespace _04ListOperations
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

            while (input != "End")
            {
                List<string> commands = input
                    .Split()
                    .ToList();

                string operation = commands[0];

                if(operation == "Add")
                {
                    int numberToAdd = int.Parse(commands[1]);
                    numbers.Add(numberToAdd);
                }
                else if(operation == "Insert")
                {
                    int numberToInsert = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, numberToInsert);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if(operation == "Remove")
                {
                    int indexToRemove = int.Parse(commands[1]);
                    
                    if(indexToRemove >= 0 && indexToRemove < numbers.Count)
                    {
                        numbers.RemoveAt(indexToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if(operation == "Shift")
                {
                    string direction = commands[1];

                    if (direction == "left")
                    {
                        int count = int.Parse(commands[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int firstNumber = numbers[0];
                            numbers.Add(firstNumber);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if(direction == "right")
                    {
                        int count = int.Parse(commands[2]);

                        for (int i = 0; i < count; i++)
                        {
                            int lastNumber = numbers[numbers.Count - 1];
                            numbers.Insert(0, lastNumber);
                            numbers.RemoveAt(numbers.Count - 1);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
