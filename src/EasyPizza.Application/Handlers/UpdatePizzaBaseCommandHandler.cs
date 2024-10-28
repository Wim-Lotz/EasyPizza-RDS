namespace EasyPizza.Application.Handlers;

public class UpdatePizzaBaseCommandHandler : IRequestHandler<UpdatePizzaBaseCommand, bool>
{
    private readonly IPizzaBaseService _pizzaBaseService;
    private readonly UpdatePizzaBaseCommandValidator _validator;

    public UpdatePizzaBaseCommandHandler(IPizzaBaseService pizzaBaseService, UpdatePizzaBaseCommandValidator validator)
    {
        _pizzaBaseService = pizzaBaseService;
        _validator = validator;
    }

    public async Task<bool> Handle(UpdatePizzaBaseCommand request, CancellationToken cancellationToken)
    {
        await  _validator.ValidateAndThrowAsync(request, cancellationToken);
        return await _pizzaBaseService.UpdateAsync(request.PizzaBase, cancellationToken);
    }
}