namespace IRunes.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var userId = this.User;
                var username = this.usersService.GetUsername(userId);

                var viewModel = new HomeUsernameViewModel
                {
                    Username = username
                };

                return this.View(viewModel, $"Home");
            }

            return this.View();
        }
    }
}
