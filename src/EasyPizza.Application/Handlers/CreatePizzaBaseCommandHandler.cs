namespace EasyPizza.Application.Handlers;

public sealed class CreatePizzaBaseCommandHandler : IRequestHandler<CreatePizzaBaseCommand>
{
    private readonly IPizzaBaseService _pizzaBaseService;
    private readonly CreatePizzaBaseCommandValidator _validator;
    
    public CreatePizzaBaseCommandHandler(IPizzaBaseService pizzaBaseService, CreatePizzaBaseCommandValidator validator)
    {
        _pizzaBaseService = pizzaBaseService;
        _validator = validator;
    }

    public async Task Handle(CreatePizzaBaseCommand command, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(command, cancellationToken);
        await _pizzaBaseService.CreateAsync(command.PizzaBase, cancellationToken);
    }
}