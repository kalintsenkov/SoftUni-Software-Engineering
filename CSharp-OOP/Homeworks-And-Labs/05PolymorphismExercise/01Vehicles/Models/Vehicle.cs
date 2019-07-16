namespace Vehicles.Models
{
    using Contracts;
    using Exceptions;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumptionPerKm { get; private set; }

        public string Drive(double distance)
        {
            var canDrive = this.FuelQuantity >= this.FuelConsumptionPerKm * distance;

            if (!canDrive)
            {
                throw new LowFuelException($"{this.GetType().Name} needs refueling");
            }

            this.FuelQuantity -= this.FuelConsumptionPerKm * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
