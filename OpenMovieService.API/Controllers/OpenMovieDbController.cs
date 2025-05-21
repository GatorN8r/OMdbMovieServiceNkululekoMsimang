using Microsoft.AspNetCore.Mvc;
using OpenMovieService.Infrastructure.Services;

namespace OpenMovieService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenMovieDbController : ControllerBase
    {

        private readonly IOMDbService _omDbService;
        public OpenMovieDbController(IOMDbService omDbService)
        {
            _omDbService = omDbService ?? throw new ArgumentNullException(nameof(omDbService));
        }

        [HttpGet("Id/{movieId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetMovieById(string movieId)
        {
            try
            {
                var movie = await _omDbService.GetMovieById(movieId);
                return Ok(movie);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Title/{name}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetMovieByTitle(string name)
        {
            try
            {
                var movie = await _omDbService.GetMovieByTitle(name);
                return Ok(movie);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
