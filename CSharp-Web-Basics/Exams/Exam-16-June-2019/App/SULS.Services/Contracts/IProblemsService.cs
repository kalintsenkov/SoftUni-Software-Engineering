namespace SULS.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IProblemsService
    {
        void Create(string name, int points);

        int GetPointsById(string id);

        Problem GetById(string id);

        IQueryable<Problem> GetAll();
    }
}
