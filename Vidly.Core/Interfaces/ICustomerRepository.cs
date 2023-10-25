using Vidly.Core.Models;

namespace Vidly.Core.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<IEnumerable<Customer>> GetAllIncludeRelatedDate();
}