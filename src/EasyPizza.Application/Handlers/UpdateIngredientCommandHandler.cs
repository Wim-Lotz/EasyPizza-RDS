namespace EasyPizza.Application.Handlers;

public class UpdateIngredientCommandHandler:IRequestHandler<UpdateIngredientCommand,bool>
{
    private readonly IIngredientService _ingredientService;
    private readonly UpdateIngredientCommandValidator _validator;

    public UpdateIngredientCommandHandler(IIngredientService ingredientService, UpdateIngredientCommandValidator validator)
    {
        _ingredientService = ingredientService;
        _validator = validator;
    }

    public async Task<bool> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        return await _ingredientService.UpdateAsync(request.Ingredient, cancellationToken);
    }
}