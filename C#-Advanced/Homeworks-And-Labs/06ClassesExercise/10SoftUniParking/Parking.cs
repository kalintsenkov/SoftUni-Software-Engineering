namespace SoftUniParking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;

        public int Count => cars.Count();

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.ContainsKey(registrationNumber))
            {
                cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber) => cars[registrationNumber];

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrarionNumber in registrationNumbers)
            {
                RemoveCar(registrarionNumber);
            }
        }
    }
}
