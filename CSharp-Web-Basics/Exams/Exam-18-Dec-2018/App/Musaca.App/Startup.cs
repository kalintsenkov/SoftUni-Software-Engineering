namespace Musaca.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Data;
    using Services;
    using Services.Contracts;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProductsService, ProductsService>();
            serviceCollection.Add<IOrdersService, OrdersService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var data = new MusacaDbContext();
            data.Database.Migrate();
        }
    }
}
