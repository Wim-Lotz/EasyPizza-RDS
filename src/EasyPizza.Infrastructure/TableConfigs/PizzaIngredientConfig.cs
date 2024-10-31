namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaIngredientConfig
{
    public PizzaIngredientConfig(EntityTypeBuilder<PizzaIngredient> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(p => p.Id);

        entityTypeBuilder.Property(p => p.IngredientPrice).IsRequired();
        
        entityTypeBuilder.HasOne(e => e.Ingredient)
            .WithMany(e => e.PizzaIngredients)
            .HasForeignKey(e => e.IngredientId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        entityTypeBuilder.HasOne(e => e.Pizza)
            .WithMany(e => e.PizzaIngredients)
            .HasForeignKey(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}