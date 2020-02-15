namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services;
    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductAddInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name?.Length < 4 || model.Name?.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                if (model.Description.Length > 10)
                {
                    return this.Redirect("/Products/Add");
                }
            }
            else
            {
                model.Description = null;
            }

            if (model.Price < 0.01M)
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.Add(
                model.Name,
                model.Description,
                model.ImageUrl,
                model.Category,
                model.Gender,
                model.Price);

            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var productDetailsViewModel = this.productsService
                .GetDetails(id, p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Category.ToString(),
                    Gender = p.Gender.ToString()
                });

            if (productDetailsViewModel == null)
            {
                return this.Error("Product not found.");
            }

            return this.View(productDetailsViewModel);
        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var isDeleted = this.productsService.Delete(id);

            if (!isDeleted)
            {
                return this.Error("Product not found.");
            }

            return this.Redirect("/");
        }
    }
}