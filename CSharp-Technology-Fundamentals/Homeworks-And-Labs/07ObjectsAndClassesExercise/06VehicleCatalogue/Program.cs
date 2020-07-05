using System;
using System.Collections.Generic;
using System.Linq;

namespace _06VehicleCatalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var vehicleList = new List<Vehicle>();

            while (input != "End")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string typeOfVehicle = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int horsepower = int.Parse(tokens[3]);

                if (typeOfVehicle == "car")
                {
                    vehicleList.Add(new Vehicle("Car", model, color, horsepower));
                }
                else if (typeOfVehicle == "truck")
                {
                    vehicleList.Add(new Vehicle("Truck", model, color, horsepower));
                }

                input = Console.ReadLine();
            }

            string modelInput = Console.ReadLine();

            while (modelInput != "Close the Catalogue")
            {
                foreach (var vehicle in vehicleList.Where(x => x.Model == modelInput))
                {
                    Console.WriteLine($"Type: {vehicle.Type}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                }

                modelInput = Console.ReadLine();
            }

            double totalCarHorsepowers = 0;
            int carCounter = 0;

            double totalTruckHorsepowers = 0;
            int truckCounter = 0;

            foreach (var vehicle in vehicleList)
            {
                if (vehicle.Type == "Car")
                {
                    totalCarHorsepowers += vehicle.Horsepower;
                    carCounter++;
                }
                else if (vehicle.Type == "Truck")
                {
                    totalTruckHorsepowers += vehicle.Horsepower;
                    truckCounter++;
                }
            }

            if (carCounter > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {totalCarHorsepowers / (double)carCounter:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (truckCounter > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {totalTruckHorsepowers / (double)truckCounter:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }
}