namespace Musaca.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IProductsService
    {
        void Create(string name, decimal price);

        string GetId(string name);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllWithActiveOrderStatusByUserId(string cashierId);
    }
}
