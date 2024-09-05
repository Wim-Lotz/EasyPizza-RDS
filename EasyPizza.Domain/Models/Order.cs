namespace EasyPizza.Domain.Models;

public class Order
{
    public Order(List<Pizza> pizzas)
    {
        Pizzas = pizzas;
        Total = CalculateTotal();
    }

    public required Guid Id { get; set; }
    public required List<Pizza> Pizzas { get; set; }
    public required decimal Total { get; set; }

    private decimal CalculateTotal()
    {
        var total = Pizzas.Sum(pizza => pizza.PizzaBase.Price);
        total += Pizzas.Sum(pizza => pizza.Ingredients.Sum(ingredient => ingredient.Price));

        return total;
    }
}