namespace Musaca.Models
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<ProductOrder>();
        }

        public string Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime IssuedOn { get; set; }

        public string CashierId { get; set; }

        public User Cashier { get; set; }

        public ICollection<ProductOrder> Products { get; set; }
    }
}
