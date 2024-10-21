namespace EasyPizza.Application.Handlers;

internal sealed class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand>
{
    private readonly IIngredientService _ingredientService;

    public CreateIngredientCommandHandler(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    public async Task Handle(CreateIngredientCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateIngredientCommandValidator(_ingredientService);
        await validator.ValidateAndThrowAsync(command, cancellationToken);

        await _ingredientService.CreateIngredient(command.Ingredient, cancellationToken);
    }
}