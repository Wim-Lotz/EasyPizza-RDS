namespace EasyPizza.Domain.Entities;

public sealed class Pizza
{
    public required Guid Id { get; init; }
    public required decimal PizzaBasePrice { get; init; }

    #region Relationships

    public OrderLine OrderLine { get; init; } = null!;
    public Guid PizzaBaseId { get; init; }
    public PizzaBase PizzaBase { get; init; } = null!;
    public IList<PizzaIngredient> PizzaIngredients { get; init; } = [];

    #endregion

}