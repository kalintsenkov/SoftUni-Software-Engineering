using System;
using System.Collections.Generic;
using System.Linq;

namespace _08VehicleCatalogue
{
    public class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var carsList = new List<Car>();
            var truckList = new List<Truck>();

            while (input != "end")
            {
                var tokens = input
                    .Split("/", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string type = tokens[0];

                if(type == "Car")
                {
                    string brand = tokens[1];
                    string model = tokens[2];
                    int horsePower = int.Parse(tokens[3]);

                    carsList.Add(new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = horsePower
                    });
                }
                else if(type == "Truck")
                {
                    string brand = tokens[1];
                    string model = tokens[2];
                    int weight = int.Parse(tokens[3]);

                    truckList.Add(new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = weight
                    });
                }

                input = Console.ReadLine();
            }

            if(carsList.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (var car in carsList.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if(truckList.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in truckList.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
