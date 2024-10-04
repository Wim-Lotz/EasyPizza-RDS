namespace EasyPizza.Application.Handlers;

internal sealed class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, Ingredient>
{
    private readonly IIngredientService _ingredientService;

    public GetIngredientsQueryHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }
    public Task<Ingredient> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
    {
        return _ingredientService.GetIngredients();
    }
}