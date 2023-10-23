using AutoMapper;
using Vidly.Core.Models;
using Vidly.Services.Dtos;

namespace Vidly.Services.Mapper;

public class MembershipTypeProfile : Profile
{
    public MembershipTypeProfile()
    {
        CreateMap<MembershipType, MembershipTypeDto>();
    }
}