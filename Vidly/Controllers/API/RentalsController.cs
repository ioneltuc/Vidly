using Microsoft.AspNetCore.Mvc;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _rentalService.GetAllRentals();

            if (rentals == null)
                return NotFound();

            return Ok(rentals);
        }

        [HttpGet("{rentalId}")]
        public async Task<IActionResult> GetRentalById(int rentalId)
        {
            var rental = await _rentalService.GetRentalById(rentalId);

            if (rental == null)
                return BadRequest();

            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(NewRentalDto newRentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rental = await _rentalService.CreateRental(newRentalDto);

            if (rental)
                return Ok(rental);

            return BadRequest();
        }

        [HttpPut("{rentalId}")]
        public async Task<IActionResult> UpdateRental(int rentalId, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var isRentalUpdated = await _rentalService.UpdateRental(rentalId, rentalDto);

            if (isRentalUpdated)
                return Ok(isRentalUpdated);

            return BadRequest();
        }

        [HttpDelete("{rentalId}")]
        public async Task<IActionResult> DeleteRental(int rentalId)
        {
            var isRentalDeleted = await _rentalService.DeleteRental(rentalId);

            if (isRentalDeleted)
                return Ok(isRentalDeleted);

            return BadRequest();
        }
    }
}