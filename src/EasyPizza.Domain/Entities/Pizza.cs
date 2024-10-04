namespace EasyPizza.Domain.Entities;

public sealed class Pizza
{
    public required Guid Id { get; init; }
    public required Guid PizzaBaseId { get; init; }
    public required IList<PizzaIngredient> PizzaIngredients { get; init; } = [];
}