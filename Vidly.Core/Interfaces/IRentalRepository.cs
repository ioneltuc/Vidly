using Vidly.Core.Models;

namespace Vidly.Core.Interfaces;

public interface IRentalRepository : IGenericRepository<Rental>
{
    Task<IEnumerable<Rental>> GetAllIncludeRelatedDate();
}