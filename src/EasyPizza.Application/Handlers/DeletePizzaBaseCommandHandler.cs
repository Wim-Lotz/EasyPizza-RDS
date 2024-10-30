namespace EasyPizza.Application.Handlers;

public sealed class DeletePizzaBaseCommandHandler : IRequestHandler<DeletePizzaBaseCommand, bool>
{
    private readonly IPizzaBaseService _pizzaBaseService;

    public DeletePizzaBaseCommandHandler(IPizzaBaseService pizzaBaseService)
    {
        _pizzaBaseService = pizzaBaseService;
    }

    public async Task<bool> Handle(DeletePizzaBaseCommand request, CancellationToken cancellationToken)
    {
        return await _pizzaBaseService.DeleteAsync(request.Id, cancellationToken);
    }
}