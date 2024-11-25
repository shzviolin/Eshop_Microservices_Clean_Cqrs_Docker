using IDP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IDP.Infrastructure.Data;

public class IDPCommandContext : DbContext
{
    private readonly IConfiguration _configuration;

    public IDPCommandContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("CommandDBConnection"));
    }

    public DbSet<User> Users { get; set; }
}
