namespace EasyPizza.Application.Validators;

public class CreatePizzaBaseCommandValidator : AbstractValidator<CreatePizzaBaseCommand>
{
    public CreatePizzaBaseCommandValidator(IPizzaBaseService service)
    {
        RuleFor(command => command.PizzaBase.Name).NotNull().NotEmpty();
        RuleFor(command => command.PizzaBase.Price).NotEqual(0);
        RuleFor(i => i.PizzaBase).Must((i, pizzaBase) => 
            !service.DoesNameSizeComboExistAsync(pizzaBase).Result).WithMessage("PizzaBase already exits");
    }
}