using EasyPizza.Domain.Enums;

namespace EasyPizza.Domain.Entities;

public class PizzaBase
{
    public PizzaBase(string name, PizzaBaseSize pizzaBaseSize, decimal price)
    {
        Name = name.ToLower();
        PizzaBaseSize = pizzaBaseSize;
        Price = price;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }
    
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required PizzaBaseSize PizzaBaseSize { get; init; }
    public required decimal Price { get; init; }
    public required DateTime CreatedDate { get; init; }
    public required DateTime UpdatedDate { get; init; }
}