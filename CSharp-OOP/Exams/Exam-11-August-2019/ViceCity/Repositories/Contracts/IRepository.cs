namespace ViceCity.Repositories.Contracts
{
    using System.Collections.Generic;

    using Models.Guns.Contracts;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(IGun model);

        bool Remove(IGun model);

        IGun Find(string name);
    }
}
