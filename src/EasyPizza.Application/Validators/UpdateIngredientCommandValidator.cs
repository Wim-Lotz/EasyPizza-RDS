namespace EasyPizza.Application.Validators;

public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
{
    private readonly IIngredientService _service;

    public UpdateIngredientCommandValidator(IIngredientService service)
    {
        _service = service;
        RuleFor(command => command.Ingredient.Name).NotNull().NotEmpty();
        RuleFor(command => command.Ingredient.Price).NotEqual(0);
        RuleFor(i => i.Ingredient).Must((i, ingredient) =>
            !service.IsNameTakenAsync(ingredient.Name, ingredient.Id).Result).WithMessage("Another ingredient has the same name");
    }
}