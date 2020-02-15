namespace Andreys.App.ViewModels.Home
{
    using System.Collections.Generic;
    using Products;

    public class HomeProductsViewModel
    {
        public IEnumerable<ProductListingViewModel> Products { get; set; }
    }
}