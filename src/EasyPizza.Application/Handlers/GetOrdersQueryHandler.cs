namespace EasyPizza.Application.Handlers;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrderService _orderService;

    public GetOrdersQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _orderService.GetAllAsync(cancellationToken);
    }
}