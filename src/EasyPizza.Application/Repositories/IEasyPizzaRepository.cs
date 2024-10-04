namespace EasyPizza.Application.Repositories;

public interface IEasyPizzaRepository
{
    Task<bool> CreateIngredientAsync(Ingredient ingredient);
    Task<Ingredient?> GetIngredientByIdAsync(Guid id);
    Task<IEnumerable<Ingredient>> GetIngredientsAsync();
    Task<bool> UpdateIngredientAsync(Ingredient ingredient);
    Task<bool> DeleteIngredientAsync(Guid id);
}