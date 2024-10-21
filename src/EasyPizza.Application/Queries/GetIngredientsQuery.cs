namespace EasyPizza.Application.Queries;

public sealed record GetIngredientsQuery : IRequest<IEnumerable<Ingredient>>;