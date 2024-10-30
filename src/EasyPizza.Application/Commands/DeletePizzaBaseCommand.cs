namespace EasyPizza.Application.Commands;

public sealed record DeletePizzaBaseCommand(Guid Id) : IRequest<bool>;