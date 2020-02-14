namespace IRunes.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class AlbumsService : IAlbumsService
    {
        private const int DefaultAlbumPrice = 0;
        private const decimal AlbumPriceReduction = 0.13M;

        private readonly RunesDbContext data;

        public AlbumsService(RunesDbContext data)
        {
            this.data = data;
        }

        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = DefaultAlbumPrice
            };

            this.data.Albums.Add(album);
            this.data.SaveChanges();
        }

        public decimal ChangePrice(string id, decimal tracksTotalPrice)
        {
            var album = this.data.Albums.FirstOrDefault(a => a.Id == id);

            var price = tracksTotalPrice - (tracksTotalPrice * AlbumPriceReduction);
            album.Price = price;

            this.data.SaveChanges();

            return price;
        }

        public bool IsAlbumExists(string id)
            => this.data.Albums.Any(a => a.Id == id);

        public Album GetById(string id)
            => this.data.Albums.FirstOrDefault(u => u.Id == id);

        public IEnumerable<Album> GetAll()
            => this.data.Albums.ToList();
    }
}