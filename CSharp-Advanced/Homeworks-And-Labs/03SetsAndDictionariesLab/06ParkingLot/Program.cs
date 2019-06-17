using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0].ToLower();
                string carNumber = tokens[1];

                if (command == "in")
                {
                    parking.Add(carNumber);
                }
                else if (command == "out")
                {
                    if (parking.Contains(carNumber))
                    {
                        parking.Remove(carNumber);
                    }
                }

                input = Console.ReadLine();
            }

            if (parking.Any())
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
