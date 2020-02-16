namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;

    public class Trip
    {
        public Trip()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Users = new HashSet<UserTrip>();
        }

        public string Id { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<UserTrip> Users { get; set; }
    }
}
