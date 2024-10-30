namespace EasyPizza.Application.Handlers;

public sealed class CreatePizzaOrderCommandHandler : IRequestHandler<CreatePizzaOrderCommand>
{
    private readonly IPizzaOrderService _pizzaOrderService;

    public CreatePizzaOrderCommandHandler(IPizzaOrderService pizzaOrderService)
    {
        _pizzaOrderService = pizzaOrderService;
    }

    public async Task Handle(CreatePizzaOrderCommand command, CancellationToken cancellationToken)
    {
        await _pizzaOrderService.CreateAsync(command.Order, command.Pizzas, cancellationToken);
    }
}