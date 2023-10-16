using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data;

public class VidlyContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }

    public VidlyContext(DbContextOptions<VidlyContext> options) : base(options)
    {
    }
}