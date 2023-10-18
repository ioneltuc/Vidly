using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class CustomersController : ControllerBase
    {
        private VidlyContext _context;
        private readonly IMapper _mapper;

        public CustomersController(VidlyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IResult GetCustomers()
        {
            return Results.Ok(_context.Customers.ToList().Select(_mapper.Map<Customer, CustomerDto>));
        }

        [HttpGet("{id}")]
        public IResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Results.NotFound();

            return Results.Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            var location = $"{Request.Scheme}://{Request.Host}{Request.Path}/{customer.Id}";
            return Results.Created(new Uri(location), customerDto);
        }

        [HttpPut("{id}")]
        public IResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return Results.BadRequest();

            var customerToEdit = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToEdit == null)
                return Results.NotFound();

            _mapper.Map(customerDto, customerToEdit);
            _context.SaveChanges();

            return Results.Ok();
        }

        [HttpDelete("{id}")]
        public IResult DeleteCustomer(int id)
        {
            var customerToDelete = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerToDelete == null)
                return Results.NotFound();

            _context.Customers.Remove(customerToDelete);
            _context.SaveChanges();

            return Results.Ok();
        }
    }
}
