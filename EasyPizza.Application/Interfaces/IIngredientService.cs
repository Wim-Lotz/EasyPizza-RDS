namespace EasyPizza.Application.Interfaces;

public interface IIngredientService
{
    Task<IngredientsResponse> GetIngredients();
}