using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private VidlyContext _context;
        private readonly IMapper _mapper;

        public NewRentalsController(VidlyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (newRentalDto.MovieIds.Count == 0)
                return Results.BadRequest("No movie ids have been given.");
            
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);

            if (customer == null)
                return Results.BadRequest("Customer id is not valid.");
            
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return Results.BadRequest("One or more movie ids are invalid.");
            
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return Results.BadRequest("Movie is not available");
                
                movie.NumberAvailable--;
                
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Results.Ok();
        }
    }
}