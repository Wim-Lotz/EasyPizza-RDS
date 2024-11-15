namespace EasyPizza.Infrastructure.TableConfigs;

public class PizzaConfig : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PizzaBasePrice).IsRequired();

        builder.HasMany(e => e.PizzaIngredients)
            .WithOne(e => e.Pizza)
            .HasForeignKey(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.PizzaBase)
            .WithMany(e => e.Pizzas)
            .HasForeignKey(e => e.PizzaBaseId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(e => e.OrderLine)
            .WithOne(e => e.Pizza)
            .HasForeignKey<OrderLine>(e => e.PizzaId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}