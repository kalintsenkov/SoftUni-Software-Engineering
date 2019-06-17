namespace DefiningClasses
{
    using System;

    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKm { get; set; }

        public double Distance { get; set; }

        public Car()
        {
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKm, double distance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.Distance = distance;
        }

        public void Drive(double amountOfKm)
        {
            bool canMove = this.FuelAmount >= amountOfKm * FuelConsumptionPerKm;

            if (canMove)
            {
                this.FuelAmount -= (amountOfKm * FuelConsumptionPerKm);
                this.Distance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.Distance}";
        }
    }
}
