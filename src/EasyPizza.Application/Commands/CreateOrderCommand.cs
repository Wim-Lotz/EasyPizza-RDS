namespace EasyPizza.Application.Commands;

public sealed record CreateOrderCommand(Order Order) : IRequest { }