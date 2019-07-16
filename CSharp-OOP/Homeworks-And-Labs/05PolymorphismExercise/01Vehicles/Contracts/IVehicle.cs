namespace Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumptionPerKm { get; }

        string Drive(double distance);

        void Refuel(double fuel);
    }
}
