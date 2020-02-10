namespace SULS.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public int GetPointsById(string id)
            => this.db.Problems
                .Where(u => u.Id == id)
                .Select(u => u.Points)
                .FirstOrDefault();

        public Problem GetById(string id)
            => this.db.Problems.FirstOrDefault(u => u.Id == id);

        public IQueryable<Problem> GetAll()
            => this.db.Problems;
    }
}
