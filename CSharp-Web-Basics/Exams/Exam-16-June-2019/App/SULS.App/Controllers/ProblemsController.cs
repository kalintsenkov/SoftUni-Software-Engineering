namespace SULS.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Problems;
    using ViewModels.Submissions;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(
            IProblemsService problemsService, 
            ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProblemCreateInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name?.Length < 5 || model.Name?.Length > 20)
            {
                return this.Redirect("/Problems/Create");
            }

            if (model.Points < 50 || model.Points > 300)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.Create(model.Name, model.Points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var problem = this.problemsService.GetById(id);
            if (problem == null)
            {
                return this.Error("We can't find this problem");
            }

            var problemDetailsViewModel = new ProblemDetailsViewModel
            {
                Name = problem.Name,
                Submissions = this.submissionsService
                    .GetAllByProblemId(id)
                    .Select(s => new SubmissionDetailsViewModel
                    {
                        Id = s.Id,
                        Username = s.User.Username,
                        AchievedResult = s.AchievedResult,
                        MaxPoints = problem.Points,
                        CreatedOn = s.CreatedOn.ToShortDateString()
                    })
                    .ToList()
            };

            return this.View(problemDetailsViewModel);
        }
    }
}
