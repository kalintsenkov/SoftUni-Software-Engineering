namespace IRunes.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ITracksService
    {
        void Create(string name, decimal price, string link, string albumId);

        Track GetById(string id);

        IEnumerable<Track> GetAllByAlbumId(string albumId);
    }
}