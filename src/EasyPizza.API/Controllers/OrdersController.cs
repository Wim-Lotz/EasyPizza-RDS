namespace EasyPizza.API.Controllers;

[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<OrdersController> _logger;
    
    public OrdersController(IMediator mediator, ILogger<OrdersController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpGet(ApiEndpoints.Orders.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var orders = await _mediator.Send(new GetOrdersQuery(), token);
        var response = orders.MapToResponse();
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Orders.Get)]
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
    
    [HttpPost(ApiEndpoints.Orders.Create)]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken token)
    {
        var order = request.MapToOrder();
        await _mediator.Send(new CreateOrderCommand(order), token);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }
}