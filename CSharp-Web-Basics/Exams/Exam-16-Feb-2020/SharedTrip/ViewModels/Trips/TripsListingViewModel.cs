namespace SharedTrip.ViewModels.Trips
{
    using System.Collections.Generic;

    public class TripsListingViewModel
    {
        public IEnumerable<TripsAllViewModel> Trips { get; set; }
    }
}
