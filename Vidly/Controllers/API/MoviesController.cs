using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanManageEverything")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GelAllMovies();

            if (movies == null)
                return NotFound();

            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMovieById(int movieId)
        {
            var movie = await _movieService.GetMovieById(movieId);

            if (movie == null)
                return BadRequest();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = await _movieService.CreateMovie(movieDto);

            if (movie)
                return Ok(movie);

            return BadRequest();
        }

        [HttpPut("{movieId}")]
        public async Task<IActionResult> UpdateMovie(int movieId, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
        
            var isMovieUpdated = await _movieService.UpdateMovie(movieId, movieDto);

            if (isMovieUpdated)
                return Ok(isMovieUpdated);

            return BadRequest();
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            var isMovieDeleted = await _movieService.DeleteMovie(movieId);

            if (isMovieDeleted)
                return Ok(isMovieDeleted);

            return BadRequest();
        }
    }
}
