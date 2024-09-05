namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaBaseConfig
{
    public PizzaBaseConfig(EntityTypeBuilder<PizzaBase> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("pizza_bases");
        
        entityTypeBuilder.Property(p => p.Id).HasColumnName("id");
        entityTypeBuilder.Property(p => p.Price).HasColumnName("price");
        entityTypeBuilder.Property(p => p.CreatedDate).HasColumnName("createdDate");
        entityTypeBuilder.Property(p => p.UpdatedDate).HasColumnName("updatedDate");
        entityTypeBuilder.Property(p => p.Name).HasColumnName("name").HasMaxLength(20);
        entityTypeBuilder.Property(p => p.PizzaBaseSize).HasColumnName("size").HasConversion<string>();
    }
}