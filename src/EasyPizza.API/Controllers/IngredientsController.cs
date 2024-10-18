using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
}