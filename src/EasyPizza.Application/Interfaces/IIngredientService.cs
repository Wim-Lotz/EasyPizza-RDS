using EasyPizza.Domain.Enums;

namespace EasyPizza.Application.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetAllAsync(string? name, string? sortField, SortOrder sortOrder, CancellationToken cancellationToken = default);
    Task<Ingredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> DoesIngredientExistAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsNameTheSame(Guid id, string name, CancellationToken cancellationToken = default);
}