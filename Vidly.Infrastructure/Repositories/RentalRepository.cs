using Microsoft.EntityFrameworkCore;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;

namespace Vidly.Infrastructure.Repositories;

public class RentalRepository : GenericRepository<Rental>, IRentalRepository
{
    public RentalRepository(VidlyContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Rental>> GetAllIncludeRelatedData()
    {
        return await _context.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Movie)
            .ToListAsync();
    }
}