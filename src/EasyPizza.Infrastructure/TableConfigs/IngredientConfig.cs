namespace EasyPizza.Infrastructure.TableConfigs;

public class IngredientConfig
{
    public IngredientConfig(EntityTypeBuilder<Ingredient> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(p => p.Id);
        
        entityTypeBuilder.Property(p => p.Name).HasMaxLength(20);
        entityTypeBuilder.Property(a => a.Name).IsRequired();

        entityTypeBuilder.Property(a => a.Price).IsRequired();

        entityTypeBuilder.HasMany(e => e.PizzaIngredients)
            .WithOne(e => e.Ingredient)
            .HasForeignKey(e => e.IngredientId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        entityTypeBuilder.HasData(
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "cheese",
                Price = 1.25M
            },
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "salami",
                Price = 2.0M
            },
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "green pepper",
                Price = 0.25M
            });
    }
}