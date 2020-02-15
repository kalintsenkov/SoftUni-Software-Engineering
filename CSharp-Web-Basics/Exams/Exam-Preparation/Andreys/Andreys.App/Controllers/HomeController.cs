namespace Andreys.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services;
    using ViewModels.Home;

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
                var products = this.productsService
                    .GetAll(p => new ProductListingViewModel
                    {
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToList();

                var viewModel = new HomeProductsViewModel
                {
                    Products = products
                };

                return this.View(viewModel, $"Home");
            }

            return this.View();
        }
    }
}