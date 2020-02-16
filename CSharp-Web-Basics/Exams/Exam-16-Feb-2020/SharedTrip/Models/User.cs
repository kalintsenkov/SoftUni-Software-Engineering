namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;

    using SIS.MvcFramework;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Trips = new HashSet<UserTrip>();
        }

        public ICollection<UserTrip> Trips { get; set; }
    }
}
