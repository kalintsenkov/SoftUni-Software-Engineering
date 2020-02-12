namespace Musaca.App.ViewModels.Users
{
    using System.Collections.Generic;
    using Orders;

    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public IEnumerable<OrderDetailViewModel> Orders { get; set; }
    }
}
