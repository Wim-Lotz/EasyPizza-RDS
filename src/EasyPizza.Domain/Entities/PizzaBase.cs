using EasyPizza.Domain.Enums;

namespace EasyPizza.Domain.Entities;

public sealed class PizzaBase
{ 
    public required Guid Id { get; init; }
    public required PizzaBaseTypes PizzaBaseType { get; init; }
    public required PizzaBaseSizes PizzaBaseSize { get; init; }
    public required decimal Price { get; init; }

    public bool Deleted { get; init; }
    
    public IList<Pizza> Pizzas { get; init; } = [];
}