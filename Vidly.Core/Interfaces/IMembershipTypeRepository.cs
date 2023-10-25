using Vidly.Core.Models;

namespace Vidly.Core.Interfaces;

public interface IMembershipTypeRepository
{
    Task<IEnumerable<MembershipType>> GetAll();
}