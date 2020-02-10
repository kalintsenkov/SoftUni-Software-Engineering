namespace SULS.App.ViewModels.Home
{
    using System.Collections.Generic;
    using Problems;

    public class HomeLoggedInViewModel
    {
        public IEnumerable<ProblemListingViewModel> Problems { get; set; }
    }
}
