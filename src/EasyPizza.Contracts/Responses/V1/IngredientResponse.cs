namespace EasyPizza.Contracts.Responses.V1;

public record struct IngredientResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required bool Deleted { get; init; }
}