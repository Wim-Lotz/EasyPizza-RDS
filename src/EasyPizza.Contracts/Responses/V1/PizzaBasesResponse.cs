namespace EasyPizza.Contracts.Responses.V1;

public record struct PizzaBasesResponse
{
    public IEnumerable<PizzaBaseResponse> Items { get; init; }
}