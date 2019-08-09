namespace MXGP.Repositories
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        private readonly List<T> models;

        protected Repository() 
            => this.models = new List<T>();

        public void Add(T model) 
            => this.models.Add(model);

        public bool Remove(T model) 
            => this.models.Remove(model);

        public IReadOnlyCollection<T> GetAll()
            => this.models.AsReadOnly();

        public abstract T GetByName(string name);
    }
}
