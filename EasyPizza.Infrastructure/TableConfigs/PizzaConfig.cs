namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaConfig
{
    public PizzaConfig(EntityTypeBuilder<Pizza> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("pizzas");
        
        entityTypeBuilder.Property(p => p.Id).HasColumnName("id");
        entityTypeBuilder.Property(p => p.CreatedDate).HasColumnName("createdDate");
        entityTypeBuilder.Property(p => p.UpdatedDate).HasColumnName("updatedDate");
        entityTypeBuilder.Property(p => p.PizzaBaseId).HasColumnName("pizzaBaseId");
    }
}