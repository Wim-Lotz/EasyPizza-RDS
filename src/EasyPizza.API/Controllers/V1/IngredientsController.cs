namespace EasyPizza.Api.Controllers.V1;

[Authorize]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IOutputCacheStore _outputCacheStore;

    public IngredientsController(IMediator mediator, IOutputCacheStore outputCacheStore)
    {
        _mediator = mediator;
        _outputCacheStore = outputCacheStore;
    }
    
    [HttpGet(ApiEndpoints.V1.Ingredients.GetAll)]
    [OutputCache(PolicyName = "IngredientsCache")]
    // [ResponseCache(Duration = 30, VaryByQueryKeys = ["name"], VaryByHeader = "Accept, Accept-Encoding", Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllIngredientsRequest request, CancellationToken token)
    {
        var (sortField, sortOrder) = request.GetSortInfo();
        var ingredients = await _mediator.Send(new GetIngredientsQuery(request.Name, sortField, sortOrder), token);
        var response = ingredients.MapToResponse();
        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.V1.Ingredients.Get)]
    [OutputCache(PolicyName = "IngredientsCache")]
    // [ResponseCache(Duration = 30, VaryByHeader = "Accept, Accept-Encoding", Location = ResponseCacheLocation.Any)]
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
   
    [Authorize(AuthConstants.TrustedMemberPolicyName)]
    [HttpPost(ApiEndpoints.V1.Ingredients.Create)]
    public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request, CancellationToken token)
    {
        var ingredient = request.MapToIngredient();
        await _mediator.Send(new CreateIngredientCommand(ingredient), token);
        await _outputCacheStore.EvictByTagAsync("ingredients", token);
        var response = ingredient.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
    }

    [Authorize(AuthConstants.TrustedMemberPolicyName)]
    [HttpPut(ApiEndpoints.V1.Ingredients.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIngredientRequest request, CancellationToken token)
    {
        var ingredient = request.MapToIngredient(id);
        var success = await _mediator.Send(new UpdateIngredientCommand(ingredient), token);
        if (!success)
        {
            return NotFound();
        }
        await _outputCacheStore.EvictByTagAsync("ingredients", token);
        var response = ingredient.MapToResponse();
        return Ok(response);
    }

    [Authorize(AuthConstants.AdminUserPolicyName)]
    [HttpDelete(ApiEndpoints.V1.Ingredients.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        var success = await _mediator.Send(new DeleteIngredientCommand(id), token);
        if (!success)
        {
            return NotFound();
        }
        await _outputCacheStore.EvictByTagAsync("ingredients", token);
        return Ok();
    }
}