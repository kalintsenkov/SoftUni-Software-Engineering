namespace SharedTrip.Controllers
{
    using System.Globalization;
    using System.Linq;

    using SIS.HTTP;
    using SIS.MvcFramework;
    
    using Services;
    using ViewModels.Trips;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripAddInputModel inputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(inputModel.StartPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrWhiteSpace(inputModel.EndPoint))
            {
                return this.Redirect("/Trips/Add");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Description))
            {
                return this.Redirect("/Trips/Add");
            }

            if (inputModel.Seats < 2 || inputModel.Seats > 6)
            {
                return this.Redirect("/Trips/Add");
            }

            if (inputModel.Description?.Length > 80)
            {
                return this.Redirect("/Trips/Add");
            }

            this.tripsService.Add(
                inputModel.StartPoint,
                inputModel.EndPoint,
                inputModel.DepartureTime,
                inputModel.ImagePath,
                inputModel.Seats,
                inputModel.Description);

            return this.Redirect("/");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService
                .GetAll(t => new TripsAllViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    Seats = t.Seats,
                    DepartureTime = t.DepartureTime
                        .ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
                })
                .ToList();

            var tripsListingViewModel = new TripsListingViewModel
            {
                Trips = trips
            };

            return this.View(tripsListingViewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService
                .GetDetails(tripId, t => new TripDetailsViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    ImagePath = t.ImagePath,
                    Seats = t.Seats,
                    Description = t.Description,
                    DepartureTime = t.DepartureTime
                        .ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture)
                });

            if (trip == null)
            {
                return this.Error("Trip not found.");
            }

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.IsTripExists(tripId))
            {
                return this.Error("Trip not found.");
            }

            var userId = this.User;
            var isUserAlreadyInCurrentTrip = this.tripsService.IsUserAlreadyInCurrentTrip(userId, tripId);
            
            if (isUserAlreadyInCurrentTrip)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("/");
        }
    }
}
