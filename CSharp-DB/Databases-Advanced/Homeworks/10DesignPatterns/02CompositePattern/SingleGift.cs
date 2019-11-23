namespace CompositePattern
{
    using System;

    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} with the price {this.Price:F2}");

            return this.Price;
        }
    }
}
