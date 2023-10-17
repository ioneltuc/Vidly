using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers;

public class MoviesController : Controller
{
    private readonly VidlyContext _context;
    
    public MoviesController(VidlyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Save(Movie movie)
    {
        if (movie.Id == 0)
        {
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
        }
        else
        {
            var movieToEdit = _context.Movies.Single(m => m.Id == movie.Id);
            movieToEdit.Name = movie.Name;
            movieToEdit.Genre = movie.Genre;
            movieToEdit.ReleasedDate = movie.ReleasedDate;
            movieToEdit.NumberInStock = movie.NumberInStock;
        }

        _context.SaveChanges();

        return RedirectToAction("Index", "Movies");
    }

    public IActionResult New()
    {
        var viewModel = new MovieFormViewModel();
        
        return View("MovieForm", viewModel);
    }
    
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

        if (movie == null)
            return NotFound();

        var viewModel = new MovieFormViewModel()
        {
            Movie = movie
        };

        return View("MovieForm", viewModel);
    }
    
    public IActionResult Index()
    {
        var movies = _context.Movies.ToList();
        
        return View(movies);
    }

    public IActionResult Details(int id)
    {
        var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
        
        return View(movie);
    }
}