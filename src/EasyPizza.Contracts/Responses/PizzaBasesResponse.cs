namespace EasyPizza.Contracts.Responses;

public sealed record PizzaBasesResponse
{
    public IEnumerable<PizzaBaseResponse> Items { get; init; } = [];
}