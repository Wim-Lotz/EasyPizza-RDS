namespace EasyPizza.Infrastructure.TableConfigs;

public class IngredientConfig
{
    public IngredientConfig(EntityTypeBuilder<Ingredient> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("ingredients");
        
        entityTypeBuilder.Property(p => p.Id).HasColumnName("id");
        entityTypeBuilder.Property(p => p.Price).HasColumnName("price");
        entityTypeBuilder.Property(p => p.CreatedDate).HasColumnName("createdDate");
        entityTypeBuilder.Property(p => p.UpdatedDate).HasColumnName("updatedDate");
        entityTypeBuilder.Property(p => p.Name).HasColumnName("name").HasMaxLength(20);
        
        var ingredient = new Ingredient("cheese", 1);
        var ingredient2 = new Ingredient("salami", 1.5M);
        var ingredient3 = new Ingredient("green pepper", 1.2M);

        entityTypeBuilder.HasData(ingredient, ingredient2, ingredient3);
    }
}