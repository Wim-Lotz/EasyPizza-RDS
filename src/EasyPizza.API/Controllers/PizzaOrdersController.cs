namespace EasyPizza.API.Controllers;

[ApiController]
public class PizzaOrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<IngredientsController> _logger;
    
    public PizzaOrdersController(IMediator mediator, ILogger<IngredientsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpPost(ApiEndpoints.PizzaOrders.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePizzaOrderRequest request, CancellationToken token)
    {
        var pizzaOrder = request.MapToPizzaOrder();
        if(pizzaOrder.Item1 is null || pizzaOrder.Item2.Count is 0)
            return BadRequest();
        await _mediator.Send(new CreatePizzaOrderCommand(pizzaOrder.Item1, pizzaOrder.Item2), token);
        return Ok();
    }
}