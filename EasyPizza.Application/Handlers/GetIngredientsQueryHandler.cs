namespace EasyPizza.Application.Handlers;

internal sealed class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, IngredientsResponse>
{
    private readonly IIngredientService _ingredientService;

    public GetIngredientsQueryHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }
    public Task<IngredientsResponse> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
    {
        return _ingredientService.GetIngredients();
    }
}