using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vidly.Core.Interfaces;
using Vidly.Infrastructure.Repositories;

namespace Vidly.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VidlyContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}