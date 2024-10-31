namespace EasyPizza.Domain.Entities;

public sealed class PizzaIngredient
{
    public required Guid Id { get; init; }
    public required decimal IngredientPrice { get; init; }

    #region Relationships

    public Ingredient Ingredient { get; init; } = null!;
    public Guid IngredientId { get; init; }
    public Pizza Pizza { get; init; } = null!;
    public Guid PizzaId { get; init; }
    
    #endregion
  
}