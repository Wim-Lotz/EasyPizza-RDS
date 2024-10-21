namespace EasyPizza.Application.Validators;

public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
{
    public CreateIngredientCommandValidator(IIngredientService service)
    {
        RuleFor(command => command.Ingredient.Name).NotNull().NotEmpty();
        RuleFor(command => command.Ingredient.Price).NotEqual(0);
        RuleFor(i => i.Ingredient.Name).Must((i, name) => 
            !service.DoesIngredientExistAsync(name).Result).WithMessage("Ingredient already exits");
    }
}