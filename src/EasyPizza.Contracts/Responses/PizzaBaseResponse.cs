namespace EasyPizza.Contracts.Responses;

public record struct PizzaBaseResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Size { get; init; }
    public required decimal Price { get; init; }
    public bool Deleted { get; init; }
}