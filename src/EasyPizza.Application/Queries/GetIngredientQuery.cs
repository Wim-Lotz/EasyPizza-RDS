namespace EasyPizza.Application.Queries;

public sealed record GetIngredientQuery(Guid Id) : IRequest<Ingredient?>;