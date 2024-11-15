using EasyPizza.Domain.Enums;

namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaBaseConfig : IEntityTypeConfiguration<PizzaBase>
{
    private const string GlutenFree = "gluten free";
    private const string ThinCrust = "thin crust";

    public void Configure(EntityTypeBuilder<PizzaBase> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(20);
        builder.Property(p => p.PizzaBaseSize).HasConversion<string>();

        builder.HasMany(e => e.Pizzas)
            .WithOne(e => e.PizzaBase)
            .HasForeignKey(e => e.PizzaBaseId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasData(
            new PizzaBase { Id = Guid.NewGuid(), Name = GlutenFree, PizzaBaseSize = PizzaBaseSize.Small, Price = 1.0M },
            new PizzaBase
            {
                Id = Guid.NewGuid(), Name = GlutenFree, PizzaBaseSize = PizzaBaseSize.Medium, Price = 1.2M
            },
            new PizzaBase { Id = Guid.NewGuid(), Name = GlutenFree, PizzaBaseSize = PizzaBaseSize.Large, Price = 1.5M },
            new PizzaBase { Id = Guid.NewGuid(), Name = ThinCrust, PizzaBaseSize = PizzaBaseSize.Small, Price = 1.0M },
            new PizzaBase { Id = Guid.NewGuid(), Name = ThinCrust, PizzaBaseSize = PizzaBaseSize.Medium, Price = 1.2M },
            new PizzaBase { Id = Guid.NewGuid(), Name = ThinCrust, PizzaBaseSize = PizzaBaseSize.Large, Price = 1.5M });
    }
}