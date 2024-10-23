namespace EasyPizza.Domain.Entities;

public sealed class PizzaIngredient
{
    public required Guid Id { get; init; }
    public required decimal IngredientPrice { get; init; }
    public required Guid IngredientId { get; init; }
    public required string IngredientName { get; init; }
    public required Guid PizzaId { get; init; }
}