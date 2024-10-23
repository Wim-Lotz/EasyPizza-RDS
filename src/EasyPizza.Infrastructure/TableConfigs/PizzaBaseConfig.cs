using EasyPizza.Domain.Enums;

namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaBaseConfig
{
    private const string GlutenFree = "gluten free";
    private const string ThinCrust = "thin crust";
    public PizzaBaseConfig(EntityTypeBuilder<PizzaBase> entityTypeBuilder)
    {
        entityTypeBuilder.Property(p => p.Name).HasMaxLength(20);
        entityTypeBuilder.Property(p => p.PizzaBaseSize).HasConversion<string>();

        entityTypeBuilder.HasData(
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                Name = GlutenFree,
                PizzaBaseSize = PizzaBaseSize.Small,
                Price = 1.0M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                Name = GlutenFree,
                PizzaBaseSize = PizzaBaseSize.Medium,
                Price = 1.2M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                Name = GlutenFree,
                PizzaBaseSize = PizzaBaseSize.Large,
                Price = 1.5M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                Name = ThinCrust,
                PizzaBaseSize = PizzaBaseSize.Small,
                Price = 1.0M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                Name = ThinCrust,
                PizzaBaseSize = PizzaBaseSize.Medium,
                Price = 1.2M
            },
            new PizzaBase
            {
                Id = Guid.NewGuid(),
                Name = ThinCrust,
                PizzaBaseSize = PizzaBaseSize.Large,
                Price = 1.5M
            });
    }
}