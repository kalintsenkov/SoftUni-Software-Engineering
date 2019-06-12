using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCars
{
    public class Tire
    {
        public int Year { get; set; }

        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }

    public class Engine
    {
        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    public class Car
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            if (this.FuelQuantity - ((this.FuelConsumption * distance) / 100) >= 0)
            {
                this.FuelQuantity -= ((distance * this.FuelConsumption) / 100);
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                var tiresInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var currentTires = new Tire[4]
                {
                    new Tire(int.Parse(tiresInfo[0]), double.Parse(tiresInfo[1])),
                    new Tire(int.Parse(tiresInfo[2]), double.Parse(tiresInfo[3])),
                    new Tire(int.Parse(tiresInfo[4]), double.Parse(tiresInfo[5])),
                    new Tire(int.Parse(tiresInfo[6]), double.Parse(tiresInfo[7])),
                };

                tires.Add(currentTires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                var enginesInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int horsePower = int.Parse(enginesInfo[0]);
                double cubicCapacity = double.Parse(enginesInfo[1]);

                var engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                var carsInfo = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string make = carsInfo[0];
                string model = carsInfo[1];
                int year = int.Parse(carsInfo[2]);
                double fuelQuantity = double.Parse(carsInfo[3]);
                double fuelConsumption = double.Parse(carsInfo[4]);
                int engineIndex = int.Parse(carsInfo[5]);
                int tiresIndex = int.Parse(carsInfo[6]);

                var car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);

                input = Console.ReadLine();
            }

            string result = GetSpecialCars(cars);

            Console.WriteLine(result);
        }

        public static string GetSpecialCars(List<Car> cars)
        {
            var specialCars = cars
                .Where(x => x.Year >= 2017)
                .Where(x => x.Engine.HorsePower > 300)
                .Where(x => x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10)
                .ToList();

            var result = new StringBuilder();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                result.AppendLine($"Make: {car.Make}");
                result.AppendLine($"Model: {car.Model}");
                result.AppendLine($"Year: {car.Year}");
                result.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                result.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }

            return result.ToString();
        }
    }
}
