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
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumationForOneKm = double.Parse(carInfo[2]);

                if (!cars.Any(x => x.Model.Contains(model)))
                {
                    var car = new Car(model, fuelAmount, fuelConsumationForOneKm, 0);

                    cars.Add(car);
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                var commandArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];

                if (command == "Drive")
                {
                    string carModel = commandArgs[1];
                    double amountOfKm = double.Parse(commandArgs[2]);

                    var car = cars
                        .Where(x => x.Model == carModel)
                        .FirstOrDefault();

                    car.Drive(amountOfKm);
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
