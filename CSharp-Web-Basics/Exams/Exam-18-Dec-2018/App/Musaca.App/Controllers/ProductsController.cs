namespace Musaca.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IOrdersService ordersService;

        public ProductsController(IProductsService productsService, IOrdersService ordersService)
        {
            this.productsService = productsService;
            this.ordersService = ordersService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProductCreateInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name?.Length < 3 || model.Name?.Length > 10)
            {
                return this.Redirect("/Products/Create");
            }

            if (model.Price < 0.01M)
            {
                return this.Redirect("/Products/Create");
            }

            this.productsService.Create(model.Name, model.Price);

            return this.Redirect("/Products/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var products = this.productsService
                .GetAll()
                .Select(p => new ProductDetailsViewModel
                {
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            return this.View(new AllProductsViewModel { Products = products });
        }

        [HttpPost]
        public HttpResponse Order(ProductOrderInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;
            var productId = this.productsService.GetId(input.Product);
            if (productId == null)
            {
                return this.Error("Product not found.");
            }

            this.ordersService.Create(userId, productId);

            return this.Redirect("/");
        }
    }
}
