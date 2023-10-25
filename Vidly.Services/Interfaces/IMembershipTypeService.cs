using Vidly.Services.Dtos;

namespace Vidly.Services.Interfaces;

public interface IMembershipTypeService
{
    Task<IEnumerable<MembershipTypeDto>> GetAllMembershipTypes();
}