namespace EasyPizza.Application.Responses;

public sealed record GetIngredientsResponse(Guid Id, string Name, decimal Price);