namespace Musaca.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;
    using Models.Enums;

    public class OrdersService : IOrdersService
    {
        private readonly MusacaDbContext data;

        public OrdersService(MusacaDbContext data)
        {
            this.data = data;
        }

        public void Create(string cashierId, string productId)
        {
            var order = new Order
            {
                Status = OrderStatus.Active,
                IssuedOn = DateTime.UtcNow,
                CashierId = cashierId
            };

            var productOrder = new ProductOrder
            {
                Order = order,
                ProductId = productId
            };

            this.data.Orders.Add(order);
            this.data.ProductsOrders.Add(productOrder);

            this.data.SaveChanges();
        }

        public void CompleteOrder(string id)
        {
            var order = this.data.Orders.FirstOrDefault(o => o.Id == id);

            order.IssuedOn = DateTime.UtcNow;
            order.Status = OrderStatus.Completed;

            this.data.SaveChanges();
        }

        public IEnumerable<string> GetAllActiveOrdersIds(string cashierId)
            => this.data.Orders
                .Where(o => o.CashierId == cashierId && o.Status == OrderStatus.Active)
                .Select(o => o.Id)
                .ToList();

        public IQueryable<ProductOrder> GetAllCompletedOrdersByUserId(string cashierId)
            => this.data.ProductsOrders
                .Where(o => o.Order.CashierId == cashierId && o.Order.Status == OrderStatus.Completed);
    }
}
