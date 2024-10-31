namespace EasyPizza.Application.Queries;

public sealed record GetOrderQuery(Guid Id) : IRequest<Order?>;