using System;
using System.Linq;
using System.Collections.Generic;

namespace _03HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommand = int.Parse(Console.ReadLine());

            List<string> namesList = new List<string>();

            for (int i = 0; i < numberOfCommand; i++)
            {
                string[] message = Console.ReadLine().Split();

                string name = message[0];

                if(message.Contains("not") && message.Contains("going!"))
                {
                    if (namesList.Contains(name))
                    {
                        namesList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else if (message.Contains("going!"))
                {
                    if (namesList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        namesList.Add(name);
                    }
                }
            }

            foreach (var name in namesList)
            {
                Console.WriteLine(name);
            }
        }
    }
}
