namespace Musaca.App.ViewModels.Home
{
    using System.Collections.Generic;
    using Products;

    public class HomeOrdersViewModel
    {
        public decimal Total { get; set; }

        public IEnumerable<ProductDetailsViewModel> Products { get; set; }
    }
}
