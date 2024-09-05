namespace EasyPizza.Domain.Entities;

public class Pizza
{
    public Pizza()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }

    public Guid Id { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
    public Guid PizzaBaseId { get; init; }
    public IList<PizzaIngredient> PizzaIngredients { get; init; } = new List<PizzaIngredient>();
}