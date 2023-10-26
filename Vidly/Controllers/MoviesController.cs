using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;
using Vidly.ViewModels;

namespace Vidly.Controllers;

[Authorize(Policy = "CanManageEverything")]
public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(MovieDto movie)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
            };

            return View("MovieForm", viewModel);
        }

        if (movie.Id == 0)
            await _movieService.CreateMovie(movie);
        else
            await _movieService.UpdateMovie(movie.Id, movie);

        return RedirectToAction("Index", "Movies");
    }

    public IActionResult New()
    {
        var viewModel = new MovieFormViewModel()
        {
            Movie = new MovieDto()
        };

        return View("MovieForm", viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _movieService.GetMovieById(id);

        if (movie == null)
            return NotFound();

        var viewModel = new MovieFormViewModel()
        {
            Movie = movie
        };

        return View("MovieForm", viewModel);
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var movie = await _movieService.GetMovieById(id);

        return View(movie);
    }
}