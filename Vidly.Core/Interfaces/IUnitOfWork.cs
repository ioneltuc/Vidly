namespace Vidly.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository Customers { get; }
    IMovieRepository Movies { get; }
    
    IMembershipTypeRepository MembershipTypes { get; }
    int Save();
}