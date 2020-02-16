namespace SharedTrip.Controllers
{
    using System.Net.Mail;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using Services;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UserLoginInputModel inputModel)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetId(inputModel.Username, inputModel.Password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterInputModel inputModel)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (inputModel.Username?.Length < 5 || inputModel.Username?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (!this.IsValidEmail(inputModel.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (inputModel.Password?.Length < 6 || inputModel.Password?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsUsernameExists(inputModel.Username))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsEmailExists(inputModel.Email))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Register(inputModel.Username, inputModel.Email, inputModel.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.SignOut();

            return this.Redirect("/");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
