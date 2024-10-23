namespace EasyPizza.Application.Handlers;

public class GetPizzaBasesQueryHandler : IRequestHandler<GetPizzaBasesQuery, IEnumerable<PizzaBase>>
{
    private readonly IPizzaBaseService _pizzaBaseService;

    public GetPizzaBasesQueryHandler(IPizzaBaseService pizzaBaseService)
    {
        _pizzaBaseService = pizzaBaseService;
    }

    public Task<IEnumerable<PizzaBase>> Handle(GetPizzaBasesQuery request, CancellationToken cancellationToken)
    {
        return _pizzaBaseService.GetAllAsync(cancellationToken);
    }
}