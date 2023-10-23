using Vidly.Core.Interfaces;
using Vidly.Core.Models;

namespace Vidly.Infrastructure.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(VidlyContext context) : base(context)
    {
    }
}