namespace VehiclesExtension.Core
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
            var busInfo = Console.ReadLine().Split();

            var car = this.CreateCar(carInfo);
            var truck = this.CreateTruck(truckInfo);
            var bus = this.CreateBus(busInfo);

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    this.MakeOperations(car, truck, bus);
                }
                catch (LowFuelException lfe)
                {
                    Console.WriteLine(lfe.Message);
                    continue;
                }
                catch (NegativeFuelException nfe)
                {
                    Console.WriteLine(nfe.Message);
                    continue;
                }
                catch (FuelOutOfTankException foote)
                {
                    Console.WriteLine(foote.Message);
                    continue;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private void MakeOperations(IVehicle car, IVehicle truck, IBus bus)
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
                else if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.Drive(distance));
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
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(liters);
                }
            }
            else if (command == "DriveEmpty")
            {
                var distance = double.Parse(commandArguments[2]);

                if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }
        }

        private IBus CreateBus(string[] input)
        {
            var busFuelQuantity = double.Parse(input[1]);
            var busLitersPerKm = double.Parse(input[2]);
            var tankCapacity = int.Parse(input[3]);

            return new Bus(busFuelQuantity, busLitersPerKm, tankCapacity);
        }

        private IVehicle CreateTruck(string[] input)
        {
            var truckFuelQuantity = double.Parse(input[1]);
            var truckLitersPerKm = double.Parse(input[2]);
            var tankCapacity = int.Parse(input[3]);

            return new Truck(truckFuelQuantity, truckLitersPerKm, tankCapacity);
        }

        private IVehicle CreateCar(string[] input)
        {
            var carFuelQuantity = double.Parse(input[1]);
            var carLitersPerKm = double.Parse(input[2]);
            var tankCapacity = int.Parse(input[3]);

            return new Car(carFuelQuantity, carLitersPerKm, tankCapacity);
        }
    }
}
