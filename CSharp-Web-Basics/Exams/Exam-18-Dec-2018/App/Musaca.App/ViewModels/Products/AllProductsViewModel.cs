namespace Musaca.App.ViewModels.Products
{
    using System.Collections.Generic;

    public class AllProductsViewModel
    {
        public IEnumerable<ProductDetailsViewModel> Products { get; set; }
    }
}
