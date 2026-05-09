using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {

        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        // GET: api/cast/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCastDetails(int id)
        {
            var cast = await _castService.GetCastDetails(id);
            if (cast == null)
            {
                return NotFound();
            }

            return Ok(cast);
        }
    }
}
