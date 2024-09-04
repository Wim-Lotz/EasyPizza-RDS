using Microsoft.Extensions.Configuration;

namespace EasyPizza.Infrastructure;

public class EasyPizzaDbContext : DbContext, IEasyPizzaDbContext
{
    private readonly IConfiguration _configuration;

    public EasyPizzaDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("EasyPizzaDb"));
    }
}