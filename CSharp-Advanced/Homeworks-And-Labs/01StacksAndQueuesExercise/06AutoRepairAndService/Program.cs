using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var service = new Queue<string>(cars);
            var servedCars = new Stack<string>();

            var sb = new StringBuilder();

            string input = Console.ReadLine();

            while (input != "End")
            {
                var tokens = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Service")
                {
                    if (service.Any())
                    {
                        string vehicle = service.Dequeue();
                        sb.AppendLine($"Vehicle {vehicle} got served.");
                        servedCars.Push(vehicle);
                    }
                }
                else if (command == "CarInfo")
                {
                    string vehicle = tokens[1];

                    if (service.Contains(vehicle))
                    {
                        sb.AppendLine("Still waiting for service.");
                    }
                    else
                    {
                        sb.AppendLine("Served.");
                    }
                }
                else if (command == "History")
                {
                    sb.AppendLine(string.Join(", ", servedCars));
                }

                input = Console.ReadLine();
            }

            Console.Write(sb);

            if (service.Any())
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", service)}");
            }
            if (servedCars.Any())
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
            }
        }
    }
}
