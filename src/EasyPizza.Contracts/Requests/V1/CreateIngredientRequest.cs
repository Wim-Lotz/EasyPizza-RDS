namespace EasyPizza.Contracts.Requests.V1;

public record struct CreateIngredientRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}