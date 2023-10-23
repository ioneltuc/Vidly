using Vidly.Core.Interfaces;
using Vidly.Core.Models;

namespace Vidly.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(VidlyContext context) : base(context)
    {
    }
}