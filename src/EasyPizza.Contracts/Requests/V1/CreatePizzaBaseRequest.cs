namespace EasyPizza.Contracts.Requests.V1;

public record struct CreatePizzaBaseRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required string Size { get; init; }
}