namespace StorageMaster.Models.Vehicles
{
    public class Van : Vehicle
    {
        private const int DefaultCapacityValue = 2;

        public Van() 
            : base(DefaultCapacityValue)
        {
        }
    }
}
