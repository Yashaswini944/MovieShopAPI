using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }

        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }

        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }

        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        public decimal? Price { get; set; }

        // Navigation
        public ICollection<MovieGenre> Genres { get; set; } = new List<MovieGenre>();
        public ICollection<Trailer> Trailers { get; set; } = new List<Trailer>();
        public ICollection<MovieCast> Casts { get; set; } = new List<MovieCast>();
        public ICollection<MovieCrew> Crews { get; set; } = new List<MovieCrew>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
