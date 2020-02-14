namespace IRunes.App.Controllers
{
    using System.Net.Mail;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
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
        public HttpResponse Login(UserLoginInputModel model)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetId(model.Username, model.Password);
            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);
            return this.Redirect("/");
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
        public HttpResponse Register(UserRegisterInputModel model)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Username?.Length < 4 || model.Username?.Length > 10)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password?.Length < 6 || model.Password?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (!this.IsValidEmail(model.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsUsernameUsed(model.Username))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsEmailUsed(model.Email))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Create(model.Username, model.Password, model.Email);

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
