namespace IRunes.App.Controllers
{
    using System.Linq;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Albums;
    using ViewModels.Tracks;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;
        private readonly ITracksService tracksService;

        public AlbumsController(IAlbumsService albumsService, ITracksService tracksService)
        {
            this.albumsService = albumsService;
            this.tracksService = tracksService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var albums = this.albumsService
                .GetAll()
                .Select(a => new AlbumsListingViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();

            var albumsAllViewModel = new AlbumsAllViewModel
            {
                Albums = albums
            };

            return this.View(albumsAllViewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(AlbumsCreateInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (model.Name?.Length < 4 || model.Name?.Length > 20)
            {
                return this.Redirect("/Albums/Create");
            }

            if (string.IsNullOrWhiteSpace(model.Cover))
            {
                return this.Redirect("/Albums/Create");
            }

            this.albumsService.Create(model.Name, model.Cover);

            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var album = this.albumsService.GetById(id);
            if (album == null)
            {
                return this.Error("Album not found.");
            }

            var tracks = this.tracksService
                .GetAllByAlbumId(id)
                .Select(t => new TracksListingViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Price = t.Price
                })
                .ToList();

            var tracksTotalPrice = tracks.Sum(t => t.Price);
            var albumPrice = this.albumsService.ChangePrice(id, tracksTotalPrice);

            var albumsDetailsViewModel = new AlbumsDetailsViewModel
            {
                Id = album.Id,
                Name = album.Name,
                Cover = album.Cover,
                Price = albumPrice,
                Tracks = tracks
            };

            return this.View(albumsDetailsViewModel);
        }
    }
}