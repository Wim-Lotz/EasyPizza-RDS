using EasyPizza.Domain.Enums;

namespace EasyPizza.Domain.Entities;

public sealed class PizzaBase
{ 
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required PizzaBaseSize PizzaBaseSize { get; init; }
    public required decimal Price { get; init; }

    public bool Deleted { get; init; }
    
    public IList<Pizza> Pizzas { get; init; } = [];
}