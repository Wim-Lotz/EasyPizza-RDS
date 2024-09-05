namespace EasyPizza.Domain.Entities;

public class Ingredient
{
    public Ingredient(string name, decimal price)
    {
        Name = name.ToLower();
        Price = price;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required DateTime CreatedDate { get; init; }
    public required DateTime UpdatedDate { get; init; }
    public required IList<PizzaIngredient> PizzaIngredients { get; init; } = new List<PizzaIngredient>();
}