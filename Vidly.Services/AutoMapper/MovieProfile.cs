using AutoMapper;
using Vidly.Core.Models;
using Vidly.Services.Dtos;

namespace Vidly.Services.Mapper;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<MovieDto, Movie>();
    }
}