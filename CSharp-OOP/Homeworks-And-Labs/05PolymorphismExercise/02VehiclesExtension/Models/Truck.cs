namespace VehiclesExtension.Models
{
    using Exceptions;

    public class Truck : Vehicle
    {
        private const double AirConditionerConsumption = 1.6;
        private const double FuelWastage = 0.95;

        public Truck(
            double fuelQuantity, 
            double fuelConsumptionPerKm,
            int tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + AirConditionerConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new NegativeFuelException();
            }

            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
                throw new FuelOutOfTankException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel * FuelWastage;
        }
    }
}
