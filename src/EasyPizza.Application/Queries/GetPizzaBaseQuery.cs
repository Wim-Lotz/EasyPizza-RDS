namespace EasyPizza.Application.Queries;

public sealed record GetPizzaBaseQuery(Guid Id) : IRequest<PizzaBase>;