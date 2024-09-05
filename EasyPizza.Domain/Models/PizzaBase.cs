using EasyPizza.Domain.Enums;

namespace EasyPizza.Domain.Models;

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
    
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required PizzaBaseSize PizzaBaseSize { get; set; }
    public required decimal Price { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime UpdatedDate { get; set; }
}