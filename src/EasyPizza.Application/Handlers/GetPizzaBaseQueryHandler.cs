namespace EasyPizza.Application.Handlers;

public class GetPizzaBaseQueryHandler : IRequestHandler<GetPizzaBaseQuery, PizzaBase?>
{
    private readonly IPizzaBaseService _pizzaBaseService;

    public GetPizzaBaseQueryHandler(IPizzaBaseService pizzaBaseService)
    {
        _pizzaBaseService = pizzaBaseService;
    }

    public async Task<PizzaBase?> Handle(GetPizzaBaseQuery request, CancellationToken cancellationToken)
    {
        return await _pizzaBaseService.GetByIdAsync(request.Id, cancellationToken);
    }
}