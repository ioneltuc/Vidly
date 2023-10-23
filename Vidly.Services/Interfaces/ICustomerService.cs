using Vidly.Services.Dtos;

namespace Vidly.Services.Interfaces;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerById(int customerId);
    Task<IEnumerable<CustomerDto>> GetAllCustomers();
    Task<bool> CreateCustomer(CustomerDto customerDto);
    Task<bool> UpdateCustomer(CustomerDto customerDto);
    Task<bool> DeleteCustomer(int customerId);
}