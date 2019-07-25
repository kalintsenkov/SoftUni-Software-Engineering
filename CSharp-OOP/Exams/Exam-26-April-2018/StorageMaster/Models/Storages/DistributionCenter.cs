namespace StorageMaster.Models.Storages
{
    using Vehicles;

    public class DistributionCenter : Storage
    {
        private const int DefaultCapacityValue = 2;
        private const int DefaultGarageSlots = 5;

        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name) 
            : base(name, DefaultCapacityValue, DefaultGarageSlots, DefaultVehicles)
        {
        }
    }
}
