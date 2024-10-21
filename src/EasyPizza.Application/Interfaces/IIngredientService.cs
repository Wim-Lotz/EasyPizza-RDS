namespace EasyPizza.Application.Interfaces;

public interface IIngredientService
{
    Task<Ingredient> GetIngredients();
    Task CreateIngredient(Ingredient ingredient, CancellationToken cancellationToken = default);
    bool DoesIngredientExist(string name, CancellationToken cancellationToken = default);
}