namespace EasyPizza.Domain.Entities;

public class PizzaIngredient
{
    public PizzaIngredient()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
    
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
    public Guid IngredientId { get; init; }
    public Guid PizzaId { get; init; }
}