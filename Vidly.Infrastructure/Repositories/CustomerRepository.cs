using Microsoft.EntityFrameworkCore;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;

namespace Vidly.Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(VidlyContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Customer>> GetAllIncludeRelatedData()
    {
        return await _context.Customers
            .Include(c => c.MembershipType)
            .ToListAsync();
    }
}