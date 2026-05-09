namespace ApplicationCore.Models
{
    public class MovieCardModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string PosterUrl { get; set; }

        // Optional: for display convenience
        public decimal? Rating { get; set; }
        public decimal? Price { get; set; }
    }
}
