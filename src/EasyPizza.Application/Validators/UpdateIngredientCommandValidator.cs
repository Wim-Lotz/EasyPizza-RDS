namespace EasyPizza.Application.Validators;

public class UpdateIngredientCommandValidator : AbstractValidator<UpdateIngredientCommand>
{
    public UpdateIngredientCommandValidator(IIngredientService service)
    {
        RuleFor(command => command.Ingredient.Name).NotNull().NotEmpty();
        RuleFor(command => command.Ingredient.Price).NotEqual(0);
        RuleFor(i => i.Ingredient).Must(ingredient =>
            service.IsNameTheSame(ingredient.Id, ingredient.Name).Result).WithMessage("Name cant be changed.");
    }
}