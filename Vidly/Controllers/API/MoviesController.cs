using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private VidlyContext _context;
        private readonly IMapper _mapper;

        public MoviesController(VidlyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IResult GetMovies()
        {
            return Results.Ok(_context.Movies.ToList().Select(_mapper.Map<Movie, MovieDto>));
        }

        [HttpGet("{id}")]
        public IResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return Results.NotFound();

            return Results.Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            
            var location = $"{Request.Scheme}://{Request.Host}{Request.Path}/{movie.Id}";
            return Results.Created(new Uri(location), movieDto);
        }

        [HttpPut("{id}")]
        public IResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var movieToEdit = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToEdit == null)
                return Results.NotFound();

            _mapper.Map(movieDto, movieToEdit);
            _context.SaveChanges();

            return Results.Ok();
        }

        [HttpDelete("{id}")]
        public IResult DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieToDelete == null)
                return Results.NotFound();

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return Results.Ok();
        }
    }
}
