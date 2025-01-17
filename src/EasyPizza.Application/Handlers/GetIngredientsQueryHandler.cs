namespace EasyPizza.Application.Handlers;

public class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, IEnumerable<Ingredient>>
{
    private readonly IIngredientService _ingredientService;

    public GetIngredientsQueryHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    public Task<IEnumerable<Ingredient>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken)
    {
        return _ingredientService.GetAllAsync(request.Name, request.SortField, request.SortOrder, cancellationToken);
    }
}