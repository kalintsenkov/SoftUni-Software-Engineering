namespace VehiclesExtension.Models
{
    using Contracts;

    public class Bus : Vehicle, IBus
    {
        private const double AirConditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + AirConditionConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumptionPerKm -= AirConditionConsumption;
            return base.Drive(distance);
        }
    }
}
