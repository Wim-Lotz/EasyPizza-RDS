namespace EasyPizza.Domain.Entities;

public sealed class OrderLine
{
    public required Guid Id { get; init; }
    public required Guid OrderId { get; init; }
    public required Guid PizzaId { get; init; }
}