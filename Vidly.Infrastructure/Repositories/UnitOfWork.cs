using Vidly.Core.Interfaces;

namespace Vidly.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ICustomerRepository Customers { get; }
    public IMovieRepository Movies { get; }
    public IMembershipTypeRepository MembershipTypes { get; }
    
    private readonly VidlyContext _context;

    public UnitOfWork(
        VidlyContext context, 
        ICustomerRepository customerRepository,
        IMovieRepository movieRepository,
        IMembershipTypeRepository membershipTypeRepository)
    {
        _context = context;
        Customers = customerRepository;
        Movies = movieRepository;
        MembershipTypes = membershipTypeRepository;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _context.Dispose();
    }
    
    public int Save()
    {
        return _context.SaveChanges();
    }
}