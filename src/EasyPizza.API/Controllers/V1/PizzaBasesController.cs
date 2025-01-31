using EasyPizza.Contracts.Requests.V1;

namespace EasyPizza.Api.Controllers.V1;

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

    [HttpGet(ApiEndpoints.V1.PizzaBases.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pizzaBases = await _mediator.Send(new GetPizzaBasesQuery(), cancellationToken);
        var response = pizzaBases.MapToResponse();
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.V1.PizzaBases.Get)]
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
    
    [HttpPost(ApiEndpoints.V1.PizzaBases.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePizzaBaseRequest request, CancellationToken cancellationToken)
    {
        var pizzaBase = request.MapToBase();
        if(pizzaBase is null)
            return BadRequest();
        await _mediator.Send(new CreatePizzaBaseCommand(pizzaBase), cancellationToken);
        var response = pizzaBase.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }
    
    [HttpPut(ApiEndpoints.V1.PizzaBases.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePizzaBaseRequest request, CancellationToken cancellationToken)
    {
        var pizzaBase = request.MapToBase(id);
        if(pizzaBase is null)
            return BadRequest();
        var success = await _mediator.Send(new UpdatePizzaBaseCommand(pizzaBase), cancellationToken);
        if(!success)
            return NotFound();
        var response = pizzaBase.MapToResponse();
        return Ok(response);
    }
    
    [HttpDelete(ApiEndpoints.V1.PizzaBases.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var success = await _mediator.Send(new DeletePizzaBaseCommand(id), cancellationToken);
        if (!success)
        {
            return NotFound();
        }
        return Ok();
    }
}