namespace EasyPizza.Application.Commands;

public sealed record UpdatePizzaBaseCommand(PizzaBase PizzaBase) : IRequest<bool>;