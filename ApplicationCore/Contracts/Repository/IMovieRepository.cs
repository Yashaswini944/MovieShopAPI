using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetHighestGrossingMovies();
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
        Task<Movie> GetMovieDetails(int id);

        // NEW: movies by genre with pagination
        Task<PaginatedResultSet<Movie>> GetMoviesByGenreAsync(
            int genreId, int pageSize, int pageNumber);
    }
}
