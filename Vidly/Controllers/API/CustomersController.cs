using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "CanManageEverything")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            if (customers == null)
                return NotFound();

            return Ok(customers);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerById(customerId);

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

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var isCustomerUpdated = await _customerService.UpdateCustomer(customerId, customerDto);

            if (isCustomerUpdated)
                return Ok(isCustomerUpdated);

            return BadRequest();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var isCustomerDeleted = await _customerService.DeleteCustomer(customerId);

            if (isCustomerDeleted)
                return Ok(isCustomerDeleted);

            return BadRequest();
        }
    }
}
