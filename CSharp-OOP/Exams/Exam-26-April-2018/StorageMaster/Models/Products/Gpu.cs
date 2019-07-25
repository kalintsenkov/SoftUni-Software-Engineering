namespace StorageMaster.Models.Products
{
    public class Gpu : Product
    {
        private const double DefaultWeight = 0.7;

        public Gpu(double price) 
            : base(price, DefaultWeight)
        {
        }
    }
}
