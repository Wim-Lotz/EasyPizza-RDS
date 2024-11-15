namespace EasyPizza.Contracts.Responses;

public record struct PizzaBasesResponse
{
    public IEnumerable<PizzaBaseResponse> Items { get; init; }
}