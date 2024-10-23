namespace EasyPizza.Application.Interfaces;

public interface IEasyPizzaDbContext
{
    DbSet<Ingredient> Ingredients { get; }
    DbSet<PizzaIngredient> PizzaIngredients { get; }
    DbSet<Pizza> Pizzas { get; }
    DbSet<PizzaBase> PizzaBases { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}