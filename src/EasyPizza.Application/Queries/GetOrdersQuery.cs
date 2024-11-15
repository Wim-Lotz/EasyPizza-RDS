namespace EasyPizza.Application.Queries;

public record struct GetOrdersQuery : IRequest<IEnumerable<Order>>;