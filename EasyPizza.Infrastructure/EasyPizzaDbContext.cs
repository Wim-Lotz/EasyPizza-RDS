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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new PizzaConfig(modelBuilder.Entity<Pizza>());
        new IngredientConfig(modelBuilder.Entity<Ingredient>());
        new PizzaBaseConfig(modelBuilder.Entity<PizzaBase>());
        new PizzaIngredientConfig(modelBuilder.Entity<PizzaIngredient>());
    }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PizzaIngredient> PizzaIngredients { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaBase> PizzaBases { get; set; }

}