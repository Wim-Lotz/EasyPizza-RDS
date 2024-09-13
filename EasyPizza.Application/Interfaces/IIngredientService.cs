namespace EasyPizza.Application.Interfaces;

public interface IIngredientService
{
    Task<IList<GetIngredientsResponse>> GetIngredients();
}