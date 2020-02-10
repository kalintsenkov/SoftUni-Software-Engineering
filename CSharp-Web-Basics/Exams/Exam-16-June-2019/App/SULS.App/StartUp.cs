namespace SULS.App
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Data;
    using Services;
    using Services.Contracts;

    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            var db = new SULSContext();
            db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}