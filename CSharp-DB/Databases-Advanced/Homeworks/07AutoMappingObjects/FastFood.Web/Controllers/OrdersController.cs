namespace FastFood.Web.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using Models.Enums;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items.Select(i => i.Name).ToList(),
                Employees = this.context.Employees.Select(e => e.Name).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var item = this.context.Items
                .FirstOrDefault(i => i.Name == model.ItemName);

            var employee = this.context.Employees
                .FirstOrDefault(e => e.Name == model.EmployeeName);

            var order = this.mapper.Map<Order>(model);

            order.EmployeeId = employee.Id;
            order.DateTime = DateTime.UtcNow;
            order.Type = Enum.Parse<OrderType>(model.OrderType);
            order.OrderItems.Add(new OrderItem
            {
                ItemId = item.Id,
                Order = order,
                Quantity = model.Quantity
            });

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                .ProjectTo<OrderAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}
