namespace Musaca.Models
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<ProductOrder>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<ProductOrder> Orders { get; set; }
    }
}
