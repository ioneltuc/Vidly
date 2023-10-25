using AutoMapper;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Services;

public class MembershipTypeService : IMembershipTypeService
{
    public IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    
    public MembershipTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<MembershipTypeDto>> GetAllMembershipTypes()
    {
        var membershipTypes = await _unitOfWork.MembershipTypes.GetAll();

        return membershipTypes.ToList().Select(_mapper.Map<MembershipType, MembershipTypeDto>);
    }
}