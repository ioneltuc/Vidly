using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers;

public class MoviesController : Controller
{
    private readonly VidlyContext _context;
    
    public MoviesController(VidlyContext context)
    {
        _context = context;
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