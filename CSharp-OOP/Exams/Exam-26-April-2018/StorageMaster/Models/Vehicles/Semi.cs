namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int DefaultCapacityValue = 10;

        public Semi() 
            : base(DefaultCapacityValue)
        {
        }
    }
}
