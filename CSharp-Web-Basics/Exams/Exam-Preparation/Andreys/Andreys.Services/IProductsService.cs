namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Models;

    public interface IProductsService
    {
        void Add(string name, string description, string imageUrl, string category, string gender, decimal price);

        TModel GetDetails<TModel>(int id, Expression<Func<Product, TModel>> selectFunc);

        IEnumerable<TModel> GetAll<TModel>(Expression<Func<Product, TModel>> selectFunc);

        bool Delete(int id);
    }
}