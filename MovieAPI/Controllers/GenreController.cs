using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMovieService _movieService;

        public GenresController(IGenreService genreService, IMovieService movieService)
        {
            _genreService = genreService;
            _movieService = movieService;
        }

        // GET: api/genres
        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetAllGenres();
            return Ok(genres);
        }

        // GET: api/genres/3/movies?pageSize=30&pageNumber=1
        [HttpGet("{id:int}/movies")]
        public async Task<IActionResult> GetMoviesByGenre(int id, int pageSize = 30, int pageNumber = 1)
        {
            var movies = await _movieService.GetMoviesByGenrePaginated(id, pageSize, pageNumber);
            return Ok(movies);
        }
    }
}
