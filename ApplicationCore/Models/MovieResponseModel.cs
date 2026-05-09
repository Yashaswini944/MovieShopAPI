using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public class MovieResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string PosterUrl { get; set; }

        // Optional fields often included in service responses
        public decimal? Rating { get; set; }
        public decimal? Price { get; set; }

        // Genre list for filtering or display
        public List<GenreModel> Genres { get; set; } = new();
    }

    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
