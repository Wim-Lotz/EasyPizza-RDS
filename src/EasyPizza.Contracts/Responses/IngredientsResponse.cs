namespace EasyPizza.Contracts.Responses;

public record struct IngredientsResponse
{
    public IEnumerable<IngredientResponse> Items { get; init; }
}