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
    }
}