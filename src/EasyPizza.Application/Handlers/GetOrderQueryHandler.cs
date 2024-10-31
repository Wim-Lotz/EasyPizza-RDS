namespace EasyPizza.Application.Handlers;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Order?>
{
    private readonly IOrderService _orderService;

    public GetOrderQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Order?> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderService.GetByIdAsync(request.Id, cancellationToken);
    }
}