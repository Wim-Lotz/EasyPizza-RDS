namespace EasyPizza.Application.Commands;

public sealed record CreatePizzaOrderCommand(Order Order, IList<Pizza> Pizzas) : IRequest { }