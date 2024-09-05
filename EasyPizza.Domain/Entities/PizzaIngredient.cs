namespace EasyPizza.Domain.Entities;

public class PizzaIngredient
{
    public PizzaIngredient()
    {
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }
    
    public required Guid Id { get; init; }
    public required DateTime CreatedDate { get; init; }
    public required DateTime UpdatedDate { get; init; }
    public required Guid IngredientId { get; init; }
    public required Guid PizzaId { get; init; }
}