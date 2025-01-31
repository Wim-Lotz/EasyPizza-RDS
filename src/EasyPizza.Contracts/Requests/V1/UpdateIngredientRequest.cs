namespace EasyPizza.Contracts.Requests.V1;

public record struct UpdateIngredientRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required bool Deleted { get; init; }
}