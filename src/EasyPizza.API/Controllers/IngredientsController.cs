using EasyPizza.API.Mapping;
using EasyPizza.Application.Repositories;
using EasyPizza.Contracts.Requests;
using EasyPizza.Contracts.Responses;
using EasyPizza.Domain.Entities;

namespace EasyPizza.API.Controllers;

[ApiController]
public class IngredientsController:ControllerBase
{
    private readonly IMediator _mediator;
    
    public IngredientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IEasyPizzaRepository _easyPizzaRepository;
    private readonly ILogger<IngredientsController> _logger;

    public IngredientsController(IEasyPizzaRepository easyPizzaRepository, ILogger<IngredientsController> logger)
    {
        _easyPizzaRepository = easyPizzaRepository;
        _logger = logger;
    }

    [HttpPost(ApiEndpoints.Ingredients.Create)]
    public async Task<IActionResult> Create([FromBody] CreateIngredientRequest request)
    {
        _logger.LogError("shit happeend");
        var ingredient = request.MapToIngredient();

        await _easyPizzaRepository.CreateIngredientAsync(ingredient);

        var response = ingredient.MapToResponse();
        return CreatedAtAction(nameof(Get), new { id = ingredient.Id }, response);
    }

    [HttpGet(ApiEndpoints.Ingredients.Get)]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        var ingredient = await _easyPizzaRepository.GetIngredientByIdAsync(id);
        if (ingredient is null)
        {
            return NotFound();
        }
        
        return Ok(ingredient.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Ingredients.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var ingredients = await _easyPizzaRepository.GetIngredientsAsync();
        
        return Ok(ingredients.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Ingredients.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateIngredientRequest request)
    {
        var ingredient = request.MapToIngredient(id);
        
        var updated = await _easyPizzaRepository.UpdateIngredientAsync(ingredient);

        if (!updated)
        {
            return NotFound();
        }
        
        return Ok(ingredient.MapToResponse());
    }

    [HttpDelete(ApiEndpoints.Ingredients.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _easyPizzaRepository.DeleteIngredientAsync(id);

        if (!deleted)
        {
            return NotFound();
        }
        return Ok();
    }

    // [HttpGet]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<IActionResult> Get()
    // {
    //     try
    //     {
    //         var result = await _mediator.Send(new GetIngredientsQuery());
    //         return Ok(result);
    //     }
    //     catch (Exception e)
    //     {
    //         return StatusCode(500, e.Message);
    //     } 
    // }
    
}