namespace EasyPizza.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController:ControllerBase
{
    private readonly IMediator _mediator;

    public IngredientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _mediator.Send(new GetIngredientsQuery());
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        } 
    }
    
}