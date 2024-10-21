namespace EasyPizza.Application.Handlers;

internal sealed class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand>
{
    private readonly IIngredientService _ingredientService;
    private readonly CreateIngredientCommandValidator _validator;

    public CreateIngredientCommandHandler(IIngredientService ingredientService, CreateIngredientCommandValidator validator)
    {
        _ingredientService = ingredientService;
        _validator = validator;
    }

    public async Task Handle(CreateIngredientCommand command, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(command, cancellationToken);

        await _ingredientService.CreateAsync(command.Ingredient, cancellationToken);
    }
}