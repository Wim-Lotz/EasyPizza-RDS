namespace EasyPizza.Contracts.Responses;

public record IngredientResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}