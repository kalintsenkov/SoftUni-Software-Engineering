namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;

    using Data;
    using Models;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext data;

        public TripsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description)
        {
            var parsedTime = DateTime
                .ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            var trip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = parsedTime,
                ImagePath = imagePath,
                Seats = seats,
                Description = description
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var trip = this.data.Trips.FirstOrDefault(t => t.Id == tripId);

            trip.Seats -= 1;

            var userTrip = new UserTrip
            {
                UserId = userId,
                Trip = trip
            };

            this.data.UsersTrips.Add(userTrip);
            this.data.SaveChanges();
        }

        public TModel GetDetails<TModel>(string id, Expression<Func<Trip, TModel>> expression)
            => this.data.Trips
                .Where(t => t.Id == id)
                .Select(expression)
                .FirstOrDefault();

        public IEnumerable<TModel> GetAll<TModel>(Expression<Func<Trip, TModel>> expression)
            => this.data.Trips
                .Select(expression)
                .ToList();

        public bool IsTripExists(string id)
            => this.data.Trips.Any(t => t.Id == id);

        public bool IsUserAlreadyInCurrentTrip(string userId, string tripId)
            => this.data.UsersTrips.Any(t => t.TripId == tripId && t.UserId == userId);
    }
}
