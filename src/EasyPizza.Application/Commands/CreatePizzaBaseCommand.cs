namespace EasyPizza.Application.Commands;

public sealed record CreatePizzaBaseCommand(PizzaBase PizzaBase) : IRequest { }