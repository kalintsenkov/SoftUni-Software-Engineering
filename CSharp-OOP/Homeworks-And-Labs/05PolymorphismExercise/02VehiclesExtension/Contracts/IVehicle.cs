namespace VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumptionPerKm { get; }

        int TankCapacity { get; }

        string Drive(double distance);

        void Refuel(double fuel);
    }
}
