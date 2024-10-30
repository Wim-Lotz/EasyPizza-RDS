namespace EasyPizza.Application.Interfaces;

public interface IPizzaOrderService
{
    Task CreateAsync(Order order, IList<Pizza> pizzas, CancellationToken cancellationToken = default);
}