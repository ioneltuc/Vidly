using Microsoft.AspNetCore.Mvc;
using Vidly.Models;

namespace Vidly.Controllers;

public class MoviesController : Controller
{
    // GET: Movies/Random
    public IActionResult Random()
    {
        var movie = new Movie()
        {
            Name = "Fast and Furious"
        };
        
        return View(movie);
    }

    [Route("movies/released/{year}/{month}")]
    public IActionResult ByReleaseYear(int year, int month)
    {
        return Content($"{year} {month}");
    }
}