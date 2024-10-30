namespace EasyPizza.Infrastructure.Services;

public class PizzaOrderService : IPizzaOrderService
{
    private readonly IEasyPizzaDbContext _context;

    public PizzaOrderService(IEasyPizzaDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Order order, IList<Pizza> pizzas, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.Pizzas.AddRangeAsync(pizzas, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}