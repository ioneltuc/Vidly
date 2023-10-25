using Microsoft.EntityFrameworkCore;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;

namespace Vidly.Infrastructure.Repositories;

public class MembershipTypeRepository : IMembershipTypeRepository
{
    protected readonly VidlyContext _context;

    public MembershipTypeRepository(VidlyContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<MembershipType>> GetAll()
    {
        return await _context.MembershipType.ToListAsync();
    }
}