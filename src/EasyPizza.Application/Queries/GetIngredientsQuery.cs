namespace EasyPizza.Application.Queries;

public sealed record GetIngredientsQuery(string? Name) : IRequest<IEnumerable<Ingredient>>;