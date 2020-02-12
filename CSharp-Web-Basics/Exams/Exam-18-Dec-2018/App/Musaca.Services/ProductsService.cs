namespace Musaca.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;

    public class ProductsService : IProductsService
    {
        private readonly MusacaDbContext data;

        public ProductsService(MusacaDbContext data)
        {
            this.data = data;
        }

        public void Create(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
        }

        public string GetId(string name)
            => this.data.Products
                .Where(p => p.Name == name)
                .Select(u => u.Id)
                .FirstOrDefault();

        public IEnumerable<Product> GetAll()
            => this.data.Products.ToList();

        public IEnumerable<Product> GetAllWithActiveOrderStatusByUserId(string cashierId)
            => this.data.ProductsOrders
                .Where(po => po.Order.CashierId == cashierId && po.Order.Status == OrderStatus.Active)
                .Select(po => po.Product);
    }
}
