namespace IRunes.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class TracksService : ITracksService
    {
        private readonly RunesDbContext data;

        public TracksService(RunesDbContext data)
        {
            this.data = data;
        }

        public void Create(string name, decimal price, string link, string albumId)
        {
            var track = new Track
            {
                Name = name,
                Price = price,
                Link = link,
                AlbumId = albumId
            };

            this.data.Tracks.Add(track);
            this.data.SaveChanges();
        }

        public Track GetById(string id)
            => this.data.Tracks.FirstOrDefault(t => t.Id == id);

        public IEnumerable<Track> GetAllByAlbumId(string albumId)
            => this.data.Tracks
                .Where(t => t.AlbumId == albumId)
                .ToList();
    }
}