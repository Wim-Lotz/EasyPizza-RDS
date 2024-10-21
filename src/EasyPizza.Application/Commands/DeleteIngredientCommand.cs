namespace EasyPizza.Application.Commands;

public sealed record DeleteIngredientCommand(Guid Id) : IRequest<bool>;