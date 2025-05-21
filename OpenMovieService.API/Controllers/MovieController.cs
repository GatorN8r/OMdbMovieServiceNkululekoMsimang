using Microsoft.AspNetCore.Mvc;
using OpenMovieService.Domain.Model;
using OpenMovieService.Infrastructure.Repositories;

namespace OpenMovieService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
       private readonly IMovieRepository _movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
          _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        [HttpPost("AddMovie")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie cannot be null");
            }
            var response = await _movieRepository.AddMovie(movie);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut("UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie cannot be null");
            }
            var response = await _movieRepository.UpdateMovie(movie);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("DeleteMovie/{movieId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteMovie(string movieId)
        {
            if (string.IsNullOrEmpty(movieId))
            {
                return BadRequest("Movie ID cannot be null or empty");
            }
            var response = await _movieRepository.DeleteMovie(movieId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetMovieById/{movieId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetMovieById(string movieId)
        {
            if (string.IsNullOrEmpty(movieId))
            {
                return BadRequest("Movie ID cannot be null or empty");
            }
            var response = await _movieRepository.GetMovieById(movieId);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("GetMovieByTitle/{name}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> GetMovieByTitle(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Movie name cannot be null or empty");
            }
            var response = await _movieRepository.GetMovieByTitle(name);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

    }
}
