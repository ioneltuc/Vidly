using AutoMapper;
using Vidly.Core.Models;
using Vidly.Services.Dtos;

namespace Vidly.Services.Mapper;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<Rental, RentalDto>().ReverseMap();
    }
}