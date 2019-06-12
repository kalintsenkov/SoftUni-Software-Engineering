using System;
using System.Linq;
using System.Collections.Generic;

namespace _07SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vip = new HashSet<string>();
            var regular = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                foreach (var symbol in input)
                {
                    if (char.IsDigit(symbol))
                    {
                        vip.Add(input);
                    }
                    else
                    {
                        regular.Add(input);
                    }

                    break;
                }

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (vip.Contains(command))
                {
                    vip.Remove(command);
                }
                if (regular.Contains(command))
                {
                    regular.Remove(command);
                }

                command = Console.ReadLine();
            }

            int missedParty = vip.Count() + regular.Count();
            Console.WriteLine(missedParty);

            foreach (var person in vip)
            {
                Console.WriteLine(person);
            }

            foreach (var person in regular)
            {
                Console.WriteLine(person);
            }
        }
    }
}
