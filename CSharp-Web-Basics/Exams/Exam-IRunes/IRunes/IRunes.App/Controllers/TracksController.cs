namespace IRunes.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using Services.Contracts;
    using ViewModels.Tracks;

    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;
        private readonly IAlbumsService albumsService;

        public TracksController(ITracksService tracksService, IAlbumsService albumsService)
        {
            this.tracksService = tracksService;
            this.albumsService = albumsService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var tracksCreateViewModel = new TracksCreateViewModel
            {
                AlbumId = albumId
            };

            return this.View(tracksCreateViewModel);
        }

        [HttpPost]
        public HttpResponse Create(TracksCreateInputModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.albumsService.IsAlbumExists(model.AlbumId))
            {
                return this.Error("Album not found.");
            }

            if (model.Name?.Length < 4 || model.Name?.Length > 20)
            {
                return this.Redirect($"/Tracks/Create?albumId={model.AlbumId}");
            }

            if (string.IsNullOrWhiteSpace(model.Link))
            {
                return this.Redirect($"/Tracks/Create?albumId={model.AlbumId}");
            }

            if (model.Price < 0.01M)
            {
                return this.Redirect($"/Tracks/Create?albumId={model.AlbumId}");
            }

            this.tracksService.Create(model.Name, model.Price, model.Link, model.AlbumId);

            return this.Redirect($"/Albums/Details?id={model.AlbumId}");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.albumsService.IsAlbumExists(albumId))
            {
                return this.Error("Album not found.");
            }

            var track = this.tracksService.GetById(trackId);
            if (track == null)
            {
                return this.Error("Track not found.");
            }

            var tracksDetailsViewModel = new TracksDetailsViewModel
            {
                Name = track.Name,
                Link = track.Link,
                Price = track.Price,
                AlbumId = albumId
            };

            return this.View(tracksDetailsViewModel);
        }
    }
}