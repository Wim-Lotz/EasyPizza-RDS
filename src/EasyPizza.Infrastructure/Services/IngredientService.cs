using EasyPizza.Domain.Enums;

namespace EasyPizza.Infrastructure.Services;

public class IngredientService : IIngredientService
{
    private readonly IEasyPizzaDbContext _context;

    public IngredientService(IEasyPizzaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ingredient>> GetAllAsync(string? name, string? sortField, SortOrder sortOrder, CancellationToken cancellationToken = default)
    {
        var query = _context.Ingredients.AsQueryable();

        if (name is not null)
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        if (sortField is not null)
        {
            if (string.Equals(sortField, "Name", StringComparison.OrdinalIgnoreCase))
            {
                query = sortOrder == SortOrder.Ascending ? query.OrderBy(x => x.Name) : query.OrderByDescending(x => x.Name);
            }
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Ingredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task CreateAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
    {
        await _context.Ingredients.AddAsync(ingredient, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default)
    {
        var result = await _context.Ingredients.Where(i => i.Id == ingredient.Id)
            .ExecuteUpdateAsync(u => u
                .SetProperty(p => p.Price, ingredient.Price)
                .SetProperty(c => c.Deleted, ingredient.Deleted), cancellationToken);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _context.Ingredients.Where(i => i.Id == id)
            .ExecuteUpdateAsync(u => u
                .SetProperty(p => p.Deleted, true), cancellationToken);
        
        return result > 0;
    }

    public async Task<bool> DoesIngredientExistAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Ingredients.AsNoTracking().AnyAsync(i => i.Name.ToLower() == name.ToLower(), cancellationToken);
    }

    public async Task<bool> IsNameTheSame(Guid id, string name, CancellationToken cancellationToken = default)
    {
        var ingredient = await _context.Ingredients.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);

        return ingredient != null && ingredient.Name == name;
    }
}