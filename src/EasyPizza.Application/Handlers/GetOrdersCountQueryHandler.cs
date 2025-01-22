namespace EasyPizza.Application.Handlers;

public class GetOrdersCountQueryHandler : IRequestHandler<GetOrdersCountQuery, int>
{
    private readonly IOrderService _orderService;

    public GetOrdersCountQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<int> Handle(GetOrdersCountQuery request, CancellationToken cancellationToken)
    {
        return await _orderService.GetCountAsync(cancellationToken);
    }
}