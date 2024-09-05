namespace EasyPizza.Domain.Entities;

public class Ingredient
{
    public Ingredient(string name, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name.ToLower();
        Price = price;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }

    public  Guid Id { get; init; }
    public  string Name { get; init; }
    public decimal Price { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
    public  IList<PizzaIngredient> PizzaIngredients { get; init; } = new List<PizzaIngredient>();
}