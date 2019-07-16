namespace Vehicles.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Exceptions;
    using Models;

    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();

            var car = this.CreateCar(carInfo);
            var truck = this.CreateTruck(truckInfo);

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    var commandArguments = Console.ReadLine()
                    .Split()
                    .ToArray();

                    var command = commandArguments[0];
                    var vehicleType = commandArguments[1];

                    if (command == "Drive")
                    {
                        var distance = double.Parse(commandArguments[2]);

                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(distance));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distance));
                        }
                    }
                    else if (command == "Refuel")
                    {
                        var liters = double.Parse(commandArguments[2]);

                        if (vehicleType == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                    }
                }
                catch (LowFuelException lfe)
                {
                    Console.WriteLine(lfe.Message);
                    continue;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private IVehicle CreateTruck(string[] input)
        {
            var truckFuelQuantity = double.Parse(input[1]);
            var truckLitersPerKm = double.Parse(input[2]);

            return new Truck(truckFuelQuantity, truckLitersPerKm);
        }

        private IVehicle CreateCar(string[] input)
        {
            var carFuelQuantity = double.Parse(input[1]);
            var carLitersPerKm = double.Parse(input[2]);

            return new Car(carFuelQuantity, carLitersPerKm);
        }
    }
}
