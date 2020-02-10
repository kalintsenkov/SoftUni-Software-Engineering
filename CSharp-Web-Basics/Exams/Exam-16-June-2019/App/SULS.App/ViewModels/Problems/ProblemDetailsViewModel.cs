namespace SULS.App.ViewModels.Problems
{
    using System.Collections.Generic;
    using Submissions;

    public class ProblemDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionDetailsViewModel> Submissions { get; set; }
    }
}
