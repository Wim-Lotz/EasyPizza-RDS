namespace EasyPizza.Contracts.Requests;

public sealed record CreatePizzaBaseRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required string Size { get; init; }
}