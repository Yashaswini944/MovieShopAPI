using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }

        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Price { get; set; }

        public decimal? Rating { get; set; }

        public List<string> Genres { get; set; } = new();
        public List<TrailerModel> Trailers { get; set; } = new();
        public List<MovieCastModel> Casts { get; set; } = new();
    }

    public class TrailerModel
    {
        public string Name { get; set; }
        public string TrailerUrl { get; set; }
    }

    public class MovieCastModel
    {
        public int CastId { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }
        public string ProfilePath { get; set; }
    }
}
