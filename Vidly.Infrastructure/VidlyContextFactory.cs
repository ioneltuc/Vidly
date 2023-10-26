using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Vidly.Infrastructure;

public class VidlyContextFactory : IDesignTimeDbContextFactory<VidlyContext>
{
    public VidlyContext CreateDbContext(string[] args)
    {
        // IConfigurationRoot configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //     .Build();
        //
        // var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        var connection = "Server=localhost;Database=Vidly;Trusted_Connection=True;TrustServerCertificate=true;";
        
        var optionsBuilder = new DbContextOptionsBuilder<VidlyContext>();
        optionsBuilder.UseSqlServer(connection);

        return new VidlyContext(optionsBuilder.Options);
    }
}