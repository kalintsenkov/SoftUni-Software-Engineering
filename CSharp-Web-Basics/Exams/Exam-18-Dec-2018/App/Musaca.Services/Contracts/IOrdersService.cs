namespace Musaca.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public interface IOrdersService
    {
        void Create(string cashierId, string productId);

        void CompleteOrder(string id);

        IEnumerable<string> GetAllActiveOrdersIds(string cashierId);

        IQueryable<ProductOrder> GetAllCompletedOrdersByUserId(string cashierId);
    }
}
