using EasyPizza.Contracts.Requests.V1;

namespace EasyPizza.Api.Controllers.V1;

[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet(ApiEndpoints.V1.Orders.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetOrdersRequest request, CancellationToken token)
    {
        var orders = await _mediator.Send(new GetOrdersQuery(request.Page, request.PageSize), token);
        var ordersCount = await _mediator.Send(new GetOrdersCountQuery(), token);
        var response = orders.MapToResponse(request.Page, request.PageSize, ordersCount);
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.V1.Orders.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
    {
        var order = await _mediator.Send(new GetOrderQuery(id), token);
        if (order is null)
        {
            return NotFound();
        }

        var response = order.MapToResponse();
        return Ok(response);
    }
    
    [HttpPost(ApiEndpoints.V1.Orders.Create)]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken token)
    {
        var order = request.MapToOrder();
        await _mediator.Send(new CreateOrderCommand(order), token);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }
}