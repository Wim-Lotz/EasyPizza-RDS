namespace EasyPizza.Application.Interfaces;

public interface IEasyPizzaDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}