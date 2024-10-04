namespace EasyPizza.Contracts.Responses;

public sealed record IngredientsResponse
{
    public IEnumerable<IngredientResponse> Items { get; init; } = [];
}