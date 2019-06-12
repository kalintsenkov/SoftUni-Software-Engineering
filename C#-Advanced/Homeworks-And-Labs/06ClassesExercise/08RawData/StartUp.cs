namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            var cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                var engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[4]
                {
                    new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
                    new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
                    new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
                    new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12])),
                };

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var result = cars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Tires.Any(y => y.Pressure < 1))
                    .ToList();

                foreach (var car in result)
                {
                    Console.WriteLine(car);
                }
            }
            else if (command == "flamable")
            {
                var result = cars
                    .Where(x => x.Cargo.Type == "flamable")
                    .Where(x => x.Engine.Power > 250)
                    .ToList();

                foreach (var car in result)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
