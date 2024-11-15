namespace EasyPizza.Contracts.Requests;

public record struct CreateIngredientRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}