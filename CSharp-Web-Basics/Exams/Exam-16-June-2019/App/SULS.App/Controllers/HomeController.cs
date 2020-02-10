namespace SULS.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Home;
    using ViewModels.Problems;

    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var problems = this.problemsService
                   .GetAll()
                   .Select(p => new ProblemListingViewModel
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Count = p.Submissions.Count()
                   })
                   .ToList();

                return this.View(new HomeLoggedInViewModel { Problems = problems }, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}