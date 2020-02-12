namespace Musaca.Models
{
    using System;
    using System.Collections.Generic;
    using SIS.MvcFramework;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public ICollection<Order> Orders { get; set; }
    }
}
