using EasyPizza.Domain.Enums;

namespace EasyPizza.Domain.Entities;

public class PizzaBase
{
    public PizzaBase(PizzaBaseTypes pizzaBaseType, PizzaBaseSizes pizzaBaseSize, decimal price)
    {
        Id = Guid.NewGuid();
        PizzaBaseType = pizzaBaseType;
        PizzaBaseSize = pizzaBaseSize;
        Price = price;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
    
    public Guid Id { get; init; }
    public PizzaBaseTypes PizzaBaseType { get; init; }
    public PizzaBaseSizes PizzaBaseSize { get; init; }
    public decimal Price { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
}