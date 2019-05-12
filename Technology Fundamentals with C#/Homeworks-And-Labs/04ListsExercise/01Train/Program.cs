using System;
using System.Collections.Generic;
using System.Linq;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengersInWagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacityInOneWagon = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end")
            {
                List<string> commands = input
                    .Split()
                    .ToList();

                if (commands[0] == "Add")
                {
                    int numberToAdd = int.Parse(commands[1]);
                    passengersInWagons.Add(numberToAdd);
                }
                else
                {
                    FittingPassengers(passengersInWagons, maxCapacityInOneWagon, commands);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", passengersInWagons));
        }

        private static void FittingPassengers(List<int> passengersInWagons, int maxCapacityInOneWagon, List<string> commands)
        {
            int numberToAdd = int.Parse(commands[0]);

            for (int i = 0; i < passengersInWagons.Count; i++)
            {
                if (passengersInWagons[i] + numberToAdd <= maxCapacityInOneWagon)
                {
                    passengersInWagons[i] += numberToAdd;
                    break;
                }
            }
        }
    }
}
