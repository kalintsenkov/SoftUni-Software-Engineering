﻿namespace IRunes.App.ViewModels.Albums
{
    using System.Collections.Generic;
    using Tracks;

    public class AlbumsDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public ICollection<TracksListingViewModel> Tracks { get; set; }
    }
}