namespace CompositePattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly IList<GiftBase> gifts;

        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            this.gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => this.gifts.Add(gift);

        public void Remove(GiftBase gift) => this.gifts.Remove(gift);

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} contains the following products with prices: ");

            return this.gifts.Sum(g => g.CalculateTotalPrice());
        }
    }
}
