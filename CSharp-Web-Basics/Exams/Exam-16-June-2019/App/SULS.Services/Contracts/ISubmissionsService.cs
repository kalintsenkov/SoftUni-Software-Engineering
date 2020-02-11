namespace SULS.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ISubmissionsService
    {
        void Create(string code, string problemId, string userId);

        void Delete(string id);

        IQueryable<Submission> GetAllByProblemId(string problemId);
    }
}
