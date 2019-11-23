namespace CompositePattern
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; protected set; }

        public decimal Price { get; protected set; }

        public abstract decimal CalculateTotalPrice();
    }
}
