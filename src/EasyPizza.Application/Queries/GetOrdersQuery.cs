namespace EasyPizza.Application.Queries;

public record struct GetOrdersQuery(int Page, int PageSize) : IRequest<IEnumerable<Order>>;