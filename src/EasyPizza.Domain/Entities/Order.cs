namespace EasyPizza.Domain.Entities;

public sealed class Order
{
    public required Guid Id { get; init; }
    public required decimal Total { get; init; }
    public required DateTime OrderDate { get; init; }
    public required int OrderNumber { get; init; }

    #region Relationships
    
    public IList<OrderLine> OrderLines { get; init; } = [];

    #endregion
}