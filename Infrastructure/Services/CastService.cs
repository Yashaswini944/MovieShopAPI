using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int castId)
        {
            var cast = await _castRepository.GetCastDetails(castId);
            if (cast == null) return null;

            return new CastDetailsModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath,

                Movies = cast.Movies.Select(m => new CastMovieModel
                {
                    MovieId = m.MovieId,
                    Title = m.Movie.Title,
                    PosterUrl = m.Movie.PosterUrl,
                    Character = m.Character
                }).ToList()
            };
        }
    }
}
