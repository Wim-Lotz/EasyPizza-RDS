namespace EasyPizza.Contracts.Responses.V1;

public record struct IngredientsResponse
{
    public IEnumerable<IngredientResponse> Items { get; init; }
}