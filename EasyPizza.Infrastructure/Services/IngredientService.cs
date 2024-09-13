using EasyPizza.Application.Responses;

namespace EasyPizza.Infrastructure.Services;

public class IngredientService : IIngredientService
{
    private readonly IEasyPizzaDbContext _context;

    public IngredientService(IEasyPizzaDbContext context)
    {
        _context = context;
    }
    
    public async Task<IList<GetIngredientsResponse>> GetIngredients()
    {
        return await _context.Ingredients.Select(i => new GetIngredientsResponse(i.Id, i.Name, i.Price)).ToListAsync();
    }
}