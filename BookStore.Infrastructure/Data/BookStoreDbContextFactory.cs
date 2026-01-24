using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookStore.Infrastructure.Data;

public class BookStoreDbContextFactory
    : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",
            "BookStore.API"
        );

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        optionsBuilder.UseNpgsql(connectionString);

        return new BookStoreDbContext(optionsBuilder.Options);
    }
}