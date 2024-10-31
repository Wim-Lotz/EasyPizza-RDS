namespace EasyPizza.Application.Handlers;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderService _orderService;

    public CreateOrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        await _orderService.CreateAsync(command.Order, cancellationToken);
    }
}