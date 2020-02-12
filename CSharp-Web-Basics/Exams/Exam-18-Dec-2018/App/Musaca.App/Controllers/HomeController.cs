namespace Musaca.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Home;
    using ViewModels.Products;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var userId = this.User;
                var products = this.productsService
                    .GetAllWithActiveOrderStatusByUserId(userId)
                    .Select(p => new ProductDetailsViewModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToList();

                var total = products.Sum(p => p.Price);

                var homeOrdersViewModel = new HomeOrdersViewModel
                {
                    Total = total,
                    Products = products
                };

                return this.View(homeOrdersViewModel, $"IndexLoggedIn");
            }

            return this.View();
        }
    }
}
