namespace EasyPizza.Application.Handlers;

public class GetIngredientQueryHandler : IRequestHandler<GetIngredientQuery, Ingredient?>
{
    private readonly IIngredientService _ingredientService;

    public GetIngredientQueryHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    public async Task<Ingredient?> Handle(GetIngredientQuery query, CancellationToken cancellationToken)
    {
        return await _ingredientService.GetByIdAsync(query.Id, cancellationToken);
    }
}