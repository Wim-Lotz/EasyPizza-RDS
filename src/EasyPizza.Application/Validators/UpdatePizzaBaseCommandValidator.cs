namespace EasyPizza.Application.Validators;

public class UpdatePizzaBaseCommandValidator : AbstractValidator<UpdatePizzaBaseCommand>
{
    public UpdatePizzaBaseCommandValidator(IPizzaBaseService pizzaBaseService)
    {
        RuleFor(command => command.PizzaBase.Name).NotNull().NotEmpty();
        RuleFor(command => command.PizzaBase.PizzaBaseSize).NotNull().NotEmpty();
        RuleFor(command => command.PizzaBase.Price).NotEqual(0);
        RuleFor(i => i.PizzaBase).Must(pizzaBase =>
            pizzaBaseService.IsNameTheSame(pizzaBase.Id, pizzaBase.Name).Result).WithMessage("Name cant be changed.");
    }
}