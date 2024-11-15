﻿namespace EasyPizza.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(Order order, CancellationToken cancellationToken = default);
}