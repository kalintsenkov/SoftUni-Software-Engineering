namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemsService;

        public SubmissionsController(
            ISubmissionsService submissionsService,
            IProblemsService problemsService)
        {
            this.submissionsService = submissionsService;
            this.problemsService = problemsService;
        }

        public HttpResponse Create(string id)
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

            var submissionCreateViewModel = new SubmissionCreateViewModel
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(submissionCreateViewModel);
        }

        [HttpPost]
        public HttpResponse Create(SubmissionCreateInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Code?.Length < 30 || model.Code?.Length > 800)
            {
                return this.Redirect($"/Submissions/Create?id={model.ProblemId}");
            }

            var userId = this.User;
            this.submissionsService.Create(model.Code, model.ProblemId, userId);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionsService.Delete(id);

            return this.Redirect("/");
        }
    }
}
