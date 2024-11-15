namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaIngredientConfig : IEntityTypeConfiguration<PizzaIngredient>
{
    public void Configure(EntityTypeBuilder<PizzaIngredient> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.IngredientPrice).IsRequired();

        builder.HasOne(e => e.Ingredient)
            .WithMany(e => e.PizzaIngredients)
            .HasForeignKey(e => e.IngredientId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.Pizza)
            .WithMany(e => e.PizzaIngredients)
            .HasForeignKey(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}