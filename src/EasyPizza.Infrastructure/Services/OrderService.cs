using Microsoft.Extensions.Logging;

namespace EasyPizza.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IEasyPizzaDbContext _context;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IEasyPizzaDbContext context, ILogger<OrderService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(or => or.OrderLines)
            .ThenInclude(t => t.Pizza)
            .ThenInclude(t => t.PizzaIngredients)
            .ThenInclude(t => t.Ingredient)
            .Include(or => or.OrderLines)
            .ThenInclude(t => t.Pizza)
            .ThenInclude(t => t.PizzaBase).ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            .Include(or => or.OrderLines)
            .ThenInclude(t => t.Pizza)
            .ThenInclude(t => t.PizzaIngredients)
            .ThenInclude(t => t.Ingredient)
            .Include(or => or.OrderLines)
            .ThenInclude(t => t.Pizza)
            .ThenInclude(t => t.PizzaBase)
            .Where(order => order.Id == id).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}