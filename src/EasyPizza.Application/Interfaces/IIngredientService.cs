namespace EasyPizza.Application.Interfaces;

public interface IIngredientService
{
    Task<Ingredient> GetIngredients();
}