namespace EasyPizza.Infrastructure.Services;

public class PizzaBaseService : IPizzaBaseService
{
    private readonly IEasyPizzaDbContext _context;

    public PizzaBaseService(IEasyPizzaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PizzaBase>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.PizzaBases.ToListAsync(cancellationToken);
    }

    public async Task<PizzaBase?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
       return await _context.PizzaBases.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task CreateAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}