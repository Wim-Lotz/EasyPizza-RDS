namespace EasyPizza.Application.Queries;

public sealed record GetPizzaBasesQuery : IRequest<IEnumerable<PizzaBase>>;