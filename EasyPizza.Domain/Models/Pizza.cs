namespace EasyPizza.Domain.Models;

public class Pizza
{
    public Pizza(List<Ingredient> ingredients, PizzaBase pizzaBase)
    {
        Ingredients = ingredients;
        PizzaBase = pizzaBase;
    }

    public Guid Id { get; set; }
    public required List<Ingredient> Ingredients { get; set; }
    public required PizzaBase PizzaBase { get; set; }
}