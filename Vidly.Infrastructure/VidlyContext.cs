using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Core.Models;

namespace Vidly.Infrastructure;

public class VidlyContext : IdentityDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MembershipType> MembershipType { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    public VidlyContext(DbContextOptions<VidlyContext> contextOptions) : base(contextOptions)
    {
    }
}