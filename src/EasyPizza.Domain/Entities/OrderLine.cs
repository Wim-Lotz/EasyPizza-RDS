namespace EasyPizza.Domain.Entities;

public sealed class OrderLine
{
    public required Guid Id { get; init; }

    #region Relationships

    public Order Order { get; init; } = null!;
    public Guid OrderId { get; init; }
    public Pizza Pizza { get; init; } = null!;
    public Guid PizzaId { get; init; }

    #endregion
   
}