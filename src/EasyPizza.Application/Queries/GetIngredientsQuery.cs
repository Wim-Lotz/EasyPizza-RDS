using EasyPizza.Domain.Enums;

namespace EasyPizza.Application.Queries;

public sealed record GetIngredientsQuery(string? Name, string? SortField, SortOrder SortOrder) : IRequest<IEnumerable<Ingredient>>;