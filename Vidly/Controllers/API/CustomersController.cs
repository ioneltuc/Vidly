using Microsoft.AspNetCore.Mvc;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers(string query = null)
        {
            var customers = await _customerService.GetAllCustomers();

            if (customers == null)
                return NotFound();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);

            if (customer == null)
                return BadRequest();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = await _customerService.CreateCustomer(customerDto);

            if (customer)
                return Ok(customer);

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var isCustomerUpdated = await _customerService.UpdateCustomer(customerDto);

            if (isCustomerUpdated)
                return Ok(isCustomerUpdated);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var isCustomerDeleted = await _customerService.DeleteCustomer(customerId);

            if (isCustomerDeleted)
                return Ok(isCustomerDeleted);

            return BadRequest();
        }
    }
}
