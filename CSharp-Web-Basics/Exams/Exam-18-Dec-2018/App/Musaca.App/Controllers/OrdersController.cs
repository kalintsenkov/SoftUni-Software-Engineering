namespace Musaca.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;

    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public HttpResponse Cashout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;
            var activeOrdersIds = this.ordersService.GetAllActiveOrdersIds(userId).ToList();

            foreach (var id in activeOrdersIds)
            {
                this.ordersService.CompleteOrder(id);
            }

            return this.Redirect("/Users/Profile");
        }
    }
}
