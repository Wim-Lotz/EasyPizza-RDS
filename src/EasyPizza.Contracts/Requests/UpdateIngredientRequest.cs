namespace EasyPizza.Contracts.Requests;

public sealed record UpdateIngredientRequest
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required bool Deleted { get; init; }
}