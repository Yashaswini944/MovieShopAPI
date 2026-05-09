namespace ApplicationCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre> Movies { get; set; } = new List<MovieGenre>();
    }
}
