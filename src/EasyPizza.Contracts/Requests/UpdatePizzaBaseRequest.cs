namespace EasyPizza.Contracts.Requests;

public record struct UpdatePizzaBaseRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required string Size { get; init; }
    public required bool Deleted { get; init; }
}