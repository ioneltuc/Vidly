using Vidly.Services.Dtos;

namespace Vidly.Services.Interfaces;

public interface IMovieService
{
    Task<MovieDto> GetMovieById(int movieId);
    Task<IEnumerable<MovieDto>> GelAllMovies();
    Task<bool> CreateMovie(MovieDto movieDto);
    Task<bool> UpdateMovie(int movieId, MovieDto movieDto);
    Task<bool> DeleteMovie(int movieId);
}