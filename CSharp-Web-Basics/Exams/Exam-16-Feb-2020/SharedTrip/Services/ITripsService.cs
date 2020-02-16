namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Models;

    public interface ITripsService
    {
        void Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        void AddUserToTrip(string userId, string tripId);

        TModel GetDetails<TModel>(string id, Expression<Func<Trip, TModel>> expression);

        IEnumerable<TModel> GetAll<TModel>(Expression<Func<Trip, TModel>> expression);

        bool IsTripExists(string id);

        bool IsUserAlreadyInCurrentTrip(string userId, string tripId);
    }
}
