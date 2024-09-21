namespace EasyPizza.Application.Repositories;

public class EasyPizzaRepository : IEasyPizzaRepository
{
    private readonly List<Ingredient> _ingredients = [];
    
    public Task<bool> CreateIngredientAsync(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
        return Task.FromResult(true);
    }

    public Task<Ingredient?> GetIngredientByIdAsync(Guid id)
    {
        var ingredient = _ingredients.SingleOrDefault(i => i.Id == id);
        return Task.FromResult(ingredient);
    }

    public Task<IEnumerable<Ingredient>> GetIngredientsAsync()
    {
        return Task.FromResult(_ingredients.AsEnumerable());
    }

    public Task<bool> UpdateIngredientAsync(Ingredient ingredient)
    {
        var ingredientIndex = _ingredients.FindIndex(i => i.Id == ingredient.Id);
        if (ingredientIndex == -1)
        {
            return Task.FromResult(false);
        }
        
        _ingredients[ingredientIndex] = ingredient;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteIngredientAsync(Guid id)
    {
        var removedCount = _ingredients.RemoveAll(i => i.Id == id);
        var ingredientsRemoved = removedCount > 0;
        return Task.FromResult(ingredientsRemoved);
    }
}