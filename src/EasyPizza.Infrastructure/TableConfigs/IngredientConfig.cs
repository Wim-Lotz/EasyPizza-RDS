namespace EasyPizza.Infrastructure.TableConfigs;

public class IngredientConfig
{
    public IngredientConfig(EntityTypeBuilder<Ingredient> entityTypeBuilder)
    {
        entityTypeBuilder.Property(p => p.Name).HasMaxLength(20);

        entityTypeBuilder.HasData(
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "Cheese",
                Price = 1.25M
            },
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "Salami",
                Price = 2.0M
            },
            new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "Green Pepper",
                Price = 0.25M
            });
    }
}