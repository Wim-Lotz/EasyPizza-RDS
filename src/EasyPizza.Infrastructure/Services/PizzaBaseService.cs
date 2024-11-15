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
        await _context.PizzaBases.AddAsync(pizzaBase, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default)
    {
        var result = await _context.PizzaBases.Where(i => i.Id == pizzaBase.Id)
            .ExecuteUpdateAsync(u => u
                .SetProperty(n => n.PizzaBaseSize, pizzaBase.PizzaBaseSize)
                .SetProperty(p => p.Price, pizzaBase.Price)
                .SetProperty(c => c.Deleted, pizzaBase.Deleted), cancellationToken);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _context.PizzaBases.Where(i => i.Id == id)
            .ExecuteUpdateAsync(u => u
                .SetProperty(p => p.Deleted, true), cancellationToken);
        
        return result > 0;
    }

    public async Task<bool> DoesNameSizeComboExistAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default)
    {
        var result = await _context.PizzaBases.AsNoTracking().
            FirstOrDefaultAsync(b => b.Name == pizzaBase.Name && b.PizzaBaseSize == pizzaBase.PizzaBaseSize, cancellationToken);
        
        return result != null;
    }
    
    public async Task<bool> IsNameTheSame(Guid id, string name, CancellationToken cancellationToken = default)
    {
        var pizzaBase = await _context.PizzaBases.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

        return pizzaBase != null && pizzaBase.Name == name;
    }
}