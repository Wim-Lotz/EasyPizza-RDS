namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaIngredientConfig
{
    public PizzaIngredientConfig(EntityTypeBuilder<PizzaIngredient> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("pizza_ingredients");
        
        entityTypeBuilder.Property(p => p.Id).HasColumnName("id");
        entityTypeBuilder.Property(p => p.CreatedDate).HasColumnName("createdDate");
        entityTypeBuilder.Property(p => p.UpdatedDate).HasColumnName("updatedDate");
        entityTypeBuilder.Property(p => p.IngredientId).HasColumnName("ingredientId");
        entityTypeBuilder.Property(p => p.PizzaId).HasColumnName("pizzaId");
    }
}