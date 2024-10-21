﻿namespace EasyPizza.Application.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Ingredient?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Ingredient ingredient, CancellationToken cancellationToken = default);
    Task<bool> DoesIngredientExistAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsNameTakenAsync(string name, Guid id, CancellationToken cancellationToken = default);
}