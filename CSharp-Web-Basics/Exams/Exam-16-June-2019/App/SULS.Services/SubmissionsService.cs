namespace SULS.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;
        private readonly Random random;
        private readonly IProblemsService problemsService;

        public SubmissionsService(
            SULSContext db, 
            Random random, 
            IProblemsService problemsService)
        {
            this.db = db;
            this.random = random;
            this.problemsService = problemsService;
        }

        public void Create(string code, string problemId, string userId)
        {
            var problemPoints = this.problemsService.GetPointsById(problemId);
            var achievedResult = this.random.Next(0, problemPoints);

            var submission = new Submission
            {
                Code = code,
                AchievedResult = achievedResult,
                CreatedOn = DateTime.UtcNow,
                ProblemId = problemId,
                UserId = userId
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.FirstOrDefault(u => u.Id == id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
