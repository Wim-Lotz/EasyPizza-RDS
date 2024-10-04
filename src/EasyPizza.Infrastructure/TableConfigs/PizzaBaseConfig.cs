using EasyPizza.Domain.Enums;

namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaBaseConfig
{
    public PizzaBaseConfig(EntityTypeBuilder<PizzaBase> entityTypeBuilder)
    {
        entityTypeBuilder.Property(p => p.PizzaBaseType).HasConversion<string>();
        entityTypeBuilder.Property(p => p.PizzaBaseSize).HasConversion<string>();

        entityTypeBuilder.HasData(
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                PizzaBaseType = PizzaBaseTypes.GlutenFree,
                PizzaBaseSize = PizzaBaseSizes.Small,
                Price = 1.0M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                PizzaBaseType = PizzaBaseTypes.GlutenFree,
                PizzaBaseSize = PizzaBaseSizes.Medium,
                Price = 1.2M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                PizzaBaseType = PizzaBaseTypes.GlutenFree,
                PizzaBaseSize = PizzaBaseSizes.Large,
                Price = 1.5M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                PizzaBaseType = PizzaBaseTypes.Thin,
                PizzaBaseSize = PizzaBaseSizes.Small,
                Price = 1.0M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                PizzaBaseType = PizzaBaseTypes.Thin,
                PizzaBaseSize = PizzaBaseSizes.Medium,
                Price = 1.2M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                PizzaBaseType = PizzaBaseTypes.Thin,
                PizzaBaseSize = PizzaBaseSizes.Large,
                Price = 1.5M
            });
    }
}