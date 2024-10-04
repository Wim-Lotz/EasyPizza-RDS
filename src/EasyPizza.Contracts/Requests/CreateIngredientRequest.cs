namespace EasyPizza.Contracts.Requests;

public sealed record CreateIngredientRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}