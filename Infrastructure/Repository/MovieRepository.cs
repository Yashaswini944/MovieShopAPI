using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            return await _dbContext.Movies
            .OrderByDescending(m => m.Reviews.Count())
                .Take(30)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _dbContext.MovieGenres
                .Where(g => g.GenreId == genreId)
                .Select(g => g.Movie)
                .ToListAsync();
        }

        public async Task<Movie> GetMovieDetails(int id)
        {
            return await _dbContext.Movies
                .Include(m => m.Genres).ThenInclude(g => g.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.Casts).ThenInclude(mc => mc.Cast)
                .Include(m => m.Crews).ThenInclude(mc => mc.Crew)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        // NEW: movies by genre with pagination
        public async Task<PaginatedResultSet<Movie>> GetMoviesByGenreAsync(
            int genreId, int pageSize, int pageNumber)
        {
            var query = _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Include(mg => mg.Movie)
                .Select(mg => mg.Movie);

            var totalCount = await query.CountAsync();

            var movies = await query
                .OrderBy(m => m.Title)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResultSet<Movie>(movies, pageNumber, pageSize, totalCount);
        }
    }
}
