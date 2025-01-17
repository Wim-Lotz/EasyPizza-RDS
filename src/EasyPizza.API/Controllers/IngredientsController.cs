using EasyPizza.API.Helpers;

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

    [HttpGet(ApiEndpoints.Ingredients.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllIngredientsRequest request, CancellationToken token)
    {
        var (sortField, sortOrder) = request.GetSortInfo();
        var ingredients = await _mediator.Send(new GetIngredientsQuery(request.Name, sortField, sortOrder), token);
        var response = ingredients.MapToResponse();
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Ingredients.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
    {
        var ingredient = await _mediator.Send(new GetIngredientQuery(id), token);
        if (ingredient is null)
        {
            return NotFound();
        }

        var response = ingredient.MapToResponse();
        return Ok(response);
    }
   
    [HttpPost(ApiEndpoints.Ingredients.Create)]
    public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request, CancellationToken token)
    {
        var ingredient = request.MapToIngredient();
        await _mediator.Send(new CreateIngredientCommand(ingredient), token);
        var response = ingredient.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [HttpPut(ApiEndpoints.Ingredients.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIngredientRequest request, CancellationToken token)
    {
        var ingredient = request.MapToIngredient(id);
        var success = await _mediator.Send(new UpdateIngredientCommand(ingredient), token);
        if (!success)
        {
            return NotFound();
        }

        var response = ingredient.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Ingredients.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        var success = await _mediator.Send(new DeleteIngredientCommand(id), token);
        if (!success)
        {
            return NotFound();
        }

        return Ok();
    }
}