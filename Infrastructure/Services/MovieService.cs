using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieCardModel>> GetAllMovies()
        {
            var movies = await _movieRepository.GetAll();

            return movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });
        }

        public async Task<MovieDetailsModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetMovieDetails(id);
            if (movie == null) return null;

            return new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                PosterUrl = movie.PosterUrl,
                BackdropUrl = movie.BackdropUrl,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                Price = movie.Price,
                Rating = movie.Reviews.Any() ? movie.Reviews.Average(r => r.Rating) : null,

                Genres = movie.Genres.Select(g => g.Genre.Name).ToList(),

                Trailers = movie.Trailers.Select(t => new TrailerModel
                {
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                }).ToList(),

                Casts = movie.Casts.Select(c => new MovieCastModel
                {
                    CastId = c.CastId,
                    Name = c.Cast.Name,
                    Character = c.Character,
                    ProfilePath = c.Cast.ProfilePath
                }).ToList()
            };
        }

        public async Task<IEnumerable<MovieCardModel>> GetHighestGrossingMovies()
        {
            var movies = await _movieRepository.GetHighestGrossingMovies();

            return movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });
        }

        public async Task<IEnumerable<MovieCardModel>> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);

            return movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });
        }

        public async Task<IEnumerable<MovieCardModel>> GetTopRatedMovies()
        {
            var movies = await _movieRepository.GetTopRatedMovies();

            return movies.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });
       
        }
        public async Task<PaginatedResultSet<MovieCardModel>> GetMoviesByGenrePaginated(int genreId, int pageSize, int pageNumber)
        {
            var pagedMovies = await _movieRepository.GetMoviesByGenreAsync(genreId, pageSize, pageNumber);

            var movieCards = pagedMovies.Data.Select(m => new MovieCardModel
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            }).ToList();

            return new PaginatedResultSet<MovieCardModel>(
                movieCards,
                pagedMovies.PageNumber,
                pagedMovies.PageSize,
                pagedMovies.TotalCount
            );
        }

    }
}
