namespace EasyPizza.Application.Queries;

public sealed record GetIngredientsQuery():IRequest<IList<GetIngredientsResponse>>;