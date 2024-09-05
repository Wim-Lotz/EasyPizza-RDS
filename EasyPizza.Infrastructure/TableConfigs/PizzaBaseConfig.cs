using EasyPizza.Domain.Enums;

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
        entityTypeBuilder.Property(p => p.PizzaBaseType).HasColumnName("type").HasConversion<string>();
        entityTypeBuilder.Property(p => p.PizzaBaseSize).HasColumnName("size").HasConversion<string>();
        
        var pizzaBase = new PizzaBase(PizzaBaseTypes.GlutenFree, PizzaBaseSizes.Small, 1);
        var pizzaBase1 = new PizzaBase(PizzaBaseTypes.GlutenFree, PizzaBaseSizes.Medium, 1.2M);
        var pizzaBase2 = new PizzaBase(PizzaBaseTypes.GlutenFree, PizzaBaseSizes.Large, 1.5M);
        
        var pizzaBase3 = new PizzaBase(PizzaBaseTypes.Thin, PizzaBaseSizes.Small, 1);
        var pizzaBase4 = new PizzaBase(PizzaBaseTypes.Thin, PizzaBaseSizes.Medium, 1.2M);
        var pizzaBase5 = new PizzaBase(PizzaBaseTypes.Thin, PizzaBaseSizes.Large, 1.5M);

        entityTypeBuilder.HasData(pizzaBase, pizzaBase1, pizzaBase2);
        entityTypeBuilder.HasData(pizzaBase3, pizzaBase4, pizzaBase5);
    }
}