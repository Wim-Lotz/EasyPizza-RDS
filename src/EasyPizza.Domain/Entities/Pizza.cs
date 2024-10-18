namespace EasyPizza.Domain.Entities;

public sealed class Pizza
{
    public required Guid Id { get; init; }
    public required Guid PizzaBaseId { get; init; }
    public required decimal PizzaBasePrice { get; init; }
    public required IList<PizzaIngredient> PizzaIngredients { get; init; } = [];
    public required IList<OrderLine> OrderLines { get; init; } = [];
}