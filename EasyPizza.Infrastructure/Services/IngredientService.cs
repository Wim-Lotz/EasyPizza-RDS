namespace EasyPizza.Infrastructure.Services;

public class IngredientService : IIngredientService
{
    private readonly IEasyPizzaDbContext _context;

    public IngredientService(IEasyPizzaDbContext context)
    {
        _context = context;
    }
    
    public async Task<IngredientsResponse> GetIngredients()
    {
        //return await _context.Ingredients.Select(i => new IngredientsResponse{Id = i.Id, i.Name, i.Price}).ToListAsync();
        var ingredients = await _context.Ingredients.ToListAsync();

        var ingredientsResponse = new IngredientsResponse
        {
            Items = ingredients.Select(ingredient => 
                new IngredientResponse { Id = ingredient.Id, Name = ingredient.Name, Price = ingredient.Price }
            )
        };
        return ingredientsResponse;
    }
}