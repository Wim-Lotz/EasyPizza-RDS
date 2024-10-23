namespace EasyPizza.API.Controllers;

[ApiController]
public class PizzaBasesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<PizzaBasesController> _logger;

    public PizzaBasesController(IMediator mediator, ILogger<PizzaBasesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet(ApiEndpoints.PizzaBases.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pizzaBases = await _mediator.Send(new GetPizzaBasesQuery(), cancellationToken);
        var response = pizzaBases.MapToResponse();
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.PizzaBases.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var pizzaBase = await _mediator.Send(new GetPizzaBaseQuery(id), cancellationToken);
        if (pizzaBase is null)
        {
            return NotFound();
        }
        var response = pizzaBase.MapToResponse();
        return Ok(response);
    }
    
    [HttpPost(ApiEndpoints.PizzaBases.Create)]
    public async Task<IActionResult> Create(CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpPut(ApiEndpoints.PizzaBases.Update)]
    public async Task<IActionResult> Update(CancellationToken cancellationToken)
    {
        return Ok();
    }
    
    [HttpDelete(ApiEndpoints.PizzaBases.Delete)]
    public async Task<IActionResult> Delete(CancellationToken cancellationToken)
    {
        return Ok();
    }
}