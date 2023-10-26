using AutoMapper;
using Vidly.Core.Interfaces;
using Vidly.Core.Models;
using Vidly.Services.Dtos;
using Vidly.Services.Interfaces;

namespace Vidly.Services;

public class MovieService : IMovieService
{
    public IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<MovieDto> GetMovieById(int movieId)
    {
        if (movieId > 0)
        {
            var movie = await _unitOfWork.Movies.GetById(movieId);

            if (movie != null)
                return _mapper.Map<Movie, MovieDto>(movie);
        }

        return null;
    }

    public async Task<IEnumerable<MovieDto>> GelAllMovies()
    {
        var movies = await _unitOfWork.Movies.GetAll();
        return movies.ToList().Select(_mapper.Map<Movie, MovieDto>);
    }

    public async Task<bool> CreateMovie(MovieDto movieDto)
    {
        if (movieDto != null)
        {
            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            movie.NumberAvailable = movie.NumberInStock;
            await _unitOfWork.Movies.Add(movie);

            var result = _unitOfWork.Save();

            if (result > 0)
                return true;

            return false;
        }

        return false;
    }

    public async Task<bool> UpdateMovie(int movieId, MovieDto movieDto)
    {
        if (movieDto != null)
        {
            var movie = await _unitOfWork.Movies.GetById(movieId);

            if (movie != null)
            {
                _mapper.Map(movieDto, movie);
                movie.NumberAvailable = movie.NumberInStock;
                _unitOfWork.Movies.Update(movie);
                
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;

                return false;
            }
        }

        return false;
    }

    public async Task<bool> DeleteMovie(int movieId)
    {
        if (movieId > 0)
        {
            var movie = await _unitOfWork.Movies.GetById(movieId);

            if (movie != null)
            {
                _unitOfWork.Movies.Delete(movie);
                
                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;

                return false;
            }
        }

        return false;
    }
}