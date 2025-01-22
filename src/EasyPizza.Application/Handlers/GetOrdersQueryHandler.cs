namespace EasyPizza.Application.Handlers;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
{
    private readonly IOrderService _orderService;
    private readonly GetOrdersQueryValidator _validator;

    public GetOrdersQueryHandler(IOrderService orderService, GetOrdersQueryValidator validator)
    {
        _orderService = orderService;
        _validator = validator;
    }

    public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        return await _orderService.GetAllAsync(request.Page, request.PageSize, cancellationToken);
    }
}