using AutoMapper;
using Vidly.Core.Models;
using Vidly.Services.Dtos;

namespace Vidly.Services.Mapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerDto, Customer>()
            .ForMember(
                c => c.Id,
                options => options.Ignore());
    }
}