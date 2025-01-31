namespace EasyPizza.Api.Controllers.V2;

[ApiController]
public class PizzaBasesController : ControllerBase
{
    private readonly IMediator _mediator;

    public PizzaBasesController(IMediator mediator, ILogger<PizzaBasesController> logger)
    {
        _mediator = mediator;
    }

    [HttpGet(ApiEndpoints.V2.PizzaBases.GetAll)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var pizzaBases = await _mediator.Send(new GetPizzaBasesQuery(), cancellationToken);
        var response = pizzaBases.MapToResponse();
        return Ok(response);
    }
}