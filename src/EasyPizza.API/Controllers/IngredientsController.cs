using EasyPizza.Application.Commands;

namespace EasyPizza.API.Controllers;

[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<IngredientsController> _logger;

    public IngredientsController(IMediator mediator, ILogger<IngredientsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet(ApiEndpoints.Ingredients.Get)]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost(ApiEndpoints.Ingredients.Create)]
    public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request, CancellationToken token)
    {
        var ingredient = request.MapToIngredient();
        await _mediator.Send(new CreateIngredientCommand(ingredient), token);
        var response = ingredient.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }
}