namespace EasyPizza.Domain.Entities;

public class Pizza
{
    public Pizza()
    {
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public required Guid Id { get; init; }
    public required DateTime CreatedDate { get; init; }
    public required DateTime UpdatedDate { get; init; }
    public required Guid PizzaBaseId { get; init; }
    public required IList<PizzaIngredient> PizzaIngredients { get; init; } = new List<PizzaIngredient>();
}