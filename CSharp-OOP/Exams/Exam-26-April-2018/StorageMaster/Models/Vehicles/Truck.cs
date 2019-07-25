namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int DefaultCapacityValue = 5;

        public Truck() 
            : base(DefaultCapacityValue)
        {
        }
    }
}
