namespace EasyPizza.Application.Handlers;

internal sealed class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, IList<GetIngredientsResponse>>
{
    private readonly IIngredientService _ingredientService;

    public GetIngredientsQueryHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }
    public Task<IList<GetIngredientsResponse>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
    {
        return _ingredientService.GetIngredients();
    }
}