namespace EasyPizza.Contracts.Responses;

public record struct OrdersResponse
{
    public IEnumerable<OrderResponse> Items { get; init; }
}