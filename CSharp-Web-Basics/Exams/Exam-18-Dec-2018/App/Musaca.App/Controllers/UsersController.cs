namespace Musaca.App.Controllers
{
    using System.Linq;
    using System.Net.Mail;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Orders;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IOrdersService orderService;

        public UsersController(IUsersService usersService, IOrdersService orderService)
        {
            this.usersService = usersService;
            this.orderService = orderService;
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

            if (model.Username?.Length < 5 || model.Username?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Email?.Length < 5 || model.Email?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (!this.IsValidEmail(model.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsEmailUsed(model.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.IsUsernameUsed(model.Username))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Create(model.Username, model.Email, model.Password);

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

        public HttpResponse Profile()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;
            var username = this.usersService.GetUsername(userId);
            var allCompletedOrders = this.orderService.GetAllCompletedOrdersByUserId(userId);

            var userProfileViewModel = new UserProfileViewModel
            {
                Username = username,
                Orders = allCompletedOrders
                    .Select(co => new OrderDetailViewModel
                    {
                        Id = co.Order.Id,
                        Total = co.Product.Price,
                        IssuedOn = co.Order.IssuedOn.ToShortDateString(),
                        Chashier = co.Order.Cashier.Username
                    })
                    .ToList()
            };

            return this.View(userProfileViewModel);
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
