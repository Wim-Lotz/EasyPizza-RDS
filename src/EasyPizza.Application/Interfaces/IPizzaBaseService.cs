using EasyPizza.Domain.Enums;

namespace EasyPizza.Application.Interfaces;

public interface IPizzaBaseService
{
    Task<IEnumerable<PizzaBase>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PizzaBase?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DoesNameSizeComboExistAsync(PizzaBase pizzaBase, CancellationToken cancellationToken = default);
    Task<bool> IsNameTheSame(Guid id, string name, CancellationToken cancellationToken = default);
}