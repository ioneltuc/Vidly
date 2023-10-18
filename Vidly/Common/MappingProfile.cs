using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>().ForMember(
            c => c.Id,
            opt => opt.Ignore());
    }
}