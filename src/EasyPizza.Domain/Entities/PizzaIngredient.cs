namespace EasyPizza.Domain.Entities;

public sealed class PizzaIngredient
{
    public required Guid Id { get; init; }
    public required decimal Price { get; init; }
    public required Guid IngredientId { get; init; }
    public required Guid PizzaId { get; init; }
}