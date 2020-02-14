namespace IRunes.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IAlbumsService
    {
        void Create(string name, string cover);

        decimal ChangePrice(string id, decimal price);

        bool IsAlbumExists(string id);

        Album GetById(string id);

        IEnumerable<Album> GetAll();
    }
}