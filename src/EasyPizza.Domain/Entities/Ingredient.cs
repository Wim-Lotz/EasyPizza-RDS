namespace EasyPizza.Domain.Entities;

public sealed class Ingredient
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public bool Deleted { get; init; }
    
    public IList<PizzaIngredient> PizzaIngredients { get; init; } = [];
}