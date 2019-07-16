namespace VehiclesExtension.Models
{
    using Contracts;
    using Exceptions;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(
            double fuelQuantity,
            double fuelConsumptionPerKm,
            int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public int TankCapacity { get; protected set; }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public double FuelConsumptionPerKm { get; protected set; }

        public string Drive(double distance)
        {
            var vehicleType = this.GetType().Name;
            var canDrive = this.FuelQuantity >= this.FuelConsumptionPerKm * distance;

            if (!canDrive)
            {
                throw new LowFuelException($"{vehicleType} needs refueling");
            }

            this.FuelQuantity -= this.FuelConsumptionPerKm * distance;

            return $"{vehicleType} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new NegativeFuelException();
            }

            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
